namespace kiemtra1tiet;

public class Game
{
    public double soDu = 1000;
    protected int totalRound { get; set; } = 0;
    protected int winRound { get; set; } = 0;
    protected int lostRound { get; set; } = 0;
    protected double maxWin { get; set; } = 0;

    public string[] linhVat = { "Bau", "Cua", "Tom", "Ca", "Ga", "Nai" };

    //Bet
    protected int[] bets { get; set; } = new int[6];

    public void Clear()
    {
        for (int i = 0; i < bets.Length; i++)
        {
            bets[i] = 0;
        }
    }

    public void AddBet(int linhVatIndex, int amount)
    {
        bets[linhVatIndex] += amount;
    }

    public void totalMoney()
    {
        int betSum = 0;
        for (int i = 0; i < bets.Length; i++)
        {
            betSum += bets[i];
        }

        Console.WriteLine(betSum);
    }


    public void setBet()
    {
        bool isRole = true;
        while (isRole)
        {
            //Đặt cược loại linh vật
            Console.WriteLine("Đặt cược nào!!!!");
            Console.WriteLine("1. Bầu /  2. Cua /  3. Tôm /");
            Console.WriteLine("4. Cá /  5. Gà /  6.Nai");
            int choice = int.Parse(Console.ReadLine());
            if (choice < 1 || choice > 6)
            {
                Console.WriteLine("Vui lòng chọn lại!");
                continue;
            }

            Console.WriteLine($"Bạn đã chọn {linhVat[choice - 1]} làm linh vật");
            int linhVatIndex = choice;

            //Số lượng tiền cược
            Console.WriteLine("Bạn muốn cược bao nhiêu");
            int tiencuoc = int.Parse(Console.ReadLine());
            if (tiencuoc > soDu)
            {
                Console.WriteLine("Tiền cược không thể lớn hơn số dư");
                continue;
            }
            else
            {
                soDu -= tiencuoc; // trừ trước tiền cược
                AddBet(choice - 1, tiencuoc);
                CuocTiep:
                Console.WriteLine("Muốn cược thêm  không");
                Console.WriteLine("1.Thêm cược");
                Console.WriteLine("2.Quay xúc xắc luôn đi!!!");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        continue; //quay lại do vòng while
                    case 2:

                        //tung xúc xắc
                        Random dice = new Random();
                        int[] rolls = new int[3];
                        for (int i = 0; i < 3; i++)
                        {
                            rolls[i] = dice.Next(1, 7);

                            Console.WriteLine($"Xúc xắc {i + 1}: {linhVat[rolls[i] - 1]}");
                        }

                        int thisRoundWinMoney = 0;
                        for (int i = 0; i < 6; i++) //xét xem mảng bets có linh vật nào được cược
                        {
                            if (bets[i] > 0)
                            {
                                int count = 0;
                                for (int j = 0; j < rolls.Length; j++) // đếm số lần linh vật i xuất hiện trong rolls
                                {
                                    if (rolls[j] == i + 1)
                                    {
                                        count++;
                                    }
                                }

                                if (count > 0) //Nhân khi có lượt thắng
                                {
                                    thisRoundWinMoney += bets[i] * count;
                                }
                                // nếu count == 0 thì đã mất tiền cược khi trừ ở trên
                            }
                        }

                        soDu += thisRoundWinMoney;
                        totalRound++;

                        if (thisRoundWinMoney > 0)
                        {
                            winRound++;
                            if (thisRoundWinMoney > maxWin)
                            {
                                maxWin = thisRoundWinMoney;
                            }

                            Console.WriteLine($"Bạn thắng {thisRoundWinMoney} điểm!");
                        }
                        else
                        {
                            lostRound++;
                            Console.WriteLine("Bạn thua ván này!");
                        }

                        Console.WriteLine($"Số dư hiện tại: {soDu}");
                        Clear(); // reset cược cho ván mới
                        isRole = false; // để ngừng vòng while
                        break;
                    default: Console.WriteLine("Vui lòng chọn 1-2");
                        goto CuocTiep;
                        break;
                }
            }
        }
    }


    public void thongKe()
    {
        Console.WriteLine("===== Thống kê =====");
        Console.WriteLine($"Tổng số ván: {totalRound}");
        Console.WriteLine($"Số ván thắng: {winRound}");
        Console.WriteLine($"Số ván thua: {lostRound}");
        Console.WriteLine($"Tiền thắng lớn nhất: {maxWin}");
        Console.WriteLine($"Số dư cuối cùng: {soDu}");
    }
}


