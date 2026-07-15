// See https://aka.ms/new-console-template for more information

//Đề 9: Game bầu cua có quản lý tài khoản

using kiemtra1tiet;
Game game = new Game();
Menu:
Console.WriteLine("1. Số dư 2. Chơi 3. thống kê 4. thoát");
string choice  = Console.ReadLine();
switch (choice)
{
    case "1" : 
        Console.WriteLine($"Số dư của bạn là {game.soDu}"); 
        goto Menu; break;
    case "2" : 
        game.setBet();
        break;
    case "3" : game.thongKe(); 
        break;
    case "4" :
        Console.WriteLine($"Thoat game");
        break;
    default: Console.WriteLine("Vui lòng chọn lại"); goto Menu; break;
}



