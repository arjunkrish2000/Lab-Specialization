using System.Security.Cryptography;
using System.Timers;
using System.Transactions;



var p1 = new Player { };

p1.Enter();

int pos = 0;
var turn = "";
int milliseconds = 2000;


while (true)
{
    
        
    Console.WriteLine("Press r to roll : ");
    turn = Console.ReadLine();

    if (turn == "r")
    {
        var rnum = p1.Roll();

        if (pos == 0 && rnum == 1)
        {
            pos = p1.Start();

        }
        else if (pos > 0)
        {
            pos = p1.Move(rnum);
        }
        else if(pos == 0) 
        { 
            Console.WriteLine("Still at position 0");
            Console.WriteLine("Roll the dice to get 1 to start");
        }


        if (pos == 100)
        {
            Console.WriteLine("You win !!!");
            Thread.Sleep(milliseconds);
            break;
        }
    }

    
    
}










class Player
{
    public string Name { get; set; }
    private int position;
    public int roll;
    public int[] snake = {1,4 };
    public int[] ladder = {2,3};
     

    public void Enter() {
        Console.WriteLine("Enter players name : ");
        Name = Console.ReadLine();
        position = 0;
    }

    public int Roll() 
    {
        Random r = new Random();
        int ran = r.Next(1, 6);
        return ran;
    }

    public int Move(int roll) 
    {

        Console.WriteLine($"Your position was at {position}");
        position = position + roll;

        for (int i = 0; i < 2; i++)
       {
                if (position == snake[i])
                {
                position = position - 3;
                    break;
                }

                if (position == ladder[i])
                {
                position = position + 10;
                    break;
                }
       }
       
       Console.WriteLine($"Your position is at : {position}");
        
        
        
        return position;

    }

    public int Start() 
    {
        Console.WriteLine($"Your position was at {position}");

        position = position + 1;
        Console.WriteLine($"Your position is at : {position}");
        return 1;

    }

  
    
}

