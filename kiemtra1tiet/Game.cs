namespace kiemtra1tiet;

public class Game
{
    public double soDu = 1000;
    protected int totalRound { get; set; } = 0;
    protected int winRound { get; set; } = 0;
    protected int lostRound { get; set; } = 0;
    protected double maxWin { get; set; } = 0;
    
    public string[] linhVat = {"Bau", "Cua", "Tom", "Ca", "Ga", "Nai"};
    
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
      bets[linhVatIndex - 1] += amount;
  }

  public void totalMoney()
  {
      int betSum = 0;
      for (int i = 0; i < bets.Length; i++)
      {
          betSum += bets[i] ;
      }
      Console.WriteLine(betSum);
  }

  
  
  
  public void setBet()
  {
      bool isRole = true;
      do
      {
          MenuCuoc:
          Console.WriteLine("Đặt cược nào!!!!");
          Console.WriteLine("1. Bầu /  2. Cua /  3. Tôm /");
          Console.WriteLine("4. Cá /  5. Gà /  6.Nai");
          int choice = int.Parse(Console.ReadLine());
          int linhVatIndex = choice;
          switch (choice)
          {
              case 1:
                  Console.WriteLine("Bạn đã chọn Bầu làm linh vật"); 
                  break;
              case 2:
                  Console.WriteLine("Bạn đã chọn Cua làm linh vật");
                  break;
              case 3:
                  Console.WriteLine("Bạn đã chọn Tôm làm linh vật");
                  break;
              case 4:
                  Console.WriteLine("Bạn đã chọn Cá làm linh vật");
                  break;
              case 5:
                  Console.WriteLine("Bạn đã chọn Gà làm linh vật");
                  break;
              case 6:
                  Console.WriteLine("Bạn đã chọn Nai làm linh vật");
                  break;
              default:
                  Console.WriteLine("Vui lòng chọn lại");
                  break;
          }

          Console.WriteLine("Bạn muốn cược bao nhiêu");
          int tiencuoc = int.Parse(Console.ReadLine());
          if (tiencuoc > soDu)
          {
              Console.WriteLine("Tiền cược không thể lớn hơn số dư");
          }
          else
          {
              soDu -= tiencuoc;
              AddBet(choice - 1, tiencuoc);
              Console.WriteLine("Muốn cược thêm  không");
              Console.WriteLine("1.Thêm cược");
              Console.WriteLine("2.Quay xúc xắc luôn đi!!!");
              int input = int.Parse(Console.ReadLine());
              switch (choice)
              {
                  case 1:
                      goto MenuCuoc;
                      break;
                  case 2:
                      isRole = false;
                      Random dice = new Random();
                      for (int i = 1; i <= 3; i++)
                      {
                          int sumWin = 0;
                          int roll = dice.Next(1, 7);

                          Console.WriteLine($"Xúc xắc {i}: [ {roll} ]");

                          if (roll == linhVatIndex)
                          {
                              Console.WriteLine($"Xúc xắc số {i} thắng");
                              sumWin += tiencuoc;
                              soDu += tiencuoc;
                              winRound++;
                              totalRound++;
                          }
                          else
                          {
                              Console.WriteLine($"xúc xắc số {i} thua");
                              lostRound++;
                              totalRound++;
                          }

                          if (sumWin > maxWin)
                          {
                              maxWin = sumWin;
                          }
                      }
                      break;
              }
          }
      } while (isRole);
  }


public void thongKe() {
    Console.WriteLine("===== Thống kê =====");
    Console.WriteLine($"Tổng số ván: {totalRound}");
    Console.WriteLine($"Số ván thắng: {winRound}");
    Console.WriteLine($"Số ván thua: {lostRound}");
    Console.WriteLine($"Tiền thắng lớn nhất: {maxWin}");
    Console.WriteLine($"Số dư cuối cùng: {soDu}");
}

}
