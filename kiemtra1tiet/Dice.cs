namespace kiemtra1tiet;

public class Dice
{
   public string[] linhVat = {"Bau", "Cua", "Tom", "Ca", "Ga", "Nai"};
    
    private Random rnd = new Random();

    public int[] diceRoll()
    {
        int[] dice = new int[3];
        for (int i = 0; i < 3; i++)
        {
            dice[i] = rnd.Next(0, 6);
            Console.WriteLine($"Kết quả {i + 1} : linhVat[{dice[i]}]");
        }

        return new int[] { };
    }

}