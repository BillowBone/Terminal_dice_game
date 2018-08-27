using System;

class billow
{
    static void draw_dice(int dice)
    {
        Console.Write("\n");
        if (dice == 1)
        {
            Console.WriteLine("-----");
            Console.WriteLine("|   |");
            Console.WriteLine("| O |");
            Console.WriteLine("|   |");
            Console.WriteLine("-----");
        }
        if (dice == 2)
        {
            Console.WriteLine("-----");
            Console.WriteLine("|  O|");
            Console.WriteLine("|   |");
            Console.WriteLine("|O  |");
            Console.WriteLine("-----");
        }
        if (dice == 3)
        {
            Console.WriteLine("-----");
            Console.WriteLine("|  O|");
            Console.WriteLine("| O |");
            Console.WriteLine("|O  |");
            Console.WriteLine("-----");
        }
        if (dice == 4)
        {
            Console.WriteLine("-----");
            Console.WriteLine("|O O|");
            Console.WriteLine("|   |");
            Console.WriteLine("|O O|");
            Console.WriteLine("-----");
        }
        if (dice == 5)
        {
            Console.WriteLine("-----");
            Console.WriteLine("|O O|");
            Console.WriteLine("| O |");
            Console.WriteLine("|O O|");
            Console.WriteLine("-----");
        }
        if (dice == 6)
        {
            Console.WriteLine("-----");
            Console.WriteLine("|O O|");
            Console.WriteLine("|O O|");
            Console.WriteLine("|O O|");
            Console.WriteLine("-----");
        }
        Console.Write("\n");
    }


    static void intro_dices(int money, ref int nb_dices, string response)
    {
        nb_dices = 0;
        Console.Write("Welcome to this dice game, you have " + money + " dollars, please choose a number of dices to play with : ");
        while (nb_dices < 1)
        {
            response = Console.ReadLine();
            int.TryParse(response, out nb_dices);
            if (nb_dices < 1)
                Console.Write("You can't play with less than 1 dice ! Please choose the number of dices you want to play with : ");
        }
    }


    static void intro_bet(int money, ref int bet, string response)
    {
        bet = 0;
        Console.Write("\nEnter the amount of money you want to bet : ");
        while (bet == 0 || bet > money)
        {
            response = Console.ReadLine();
            int.TryParse(response, out bet);
            if (bet == 0 || bet > money)
                Console.Write("Come on ! You have to bet a number between 1 and " + money + " : ");
        }
    }


    static void intro_number(int nb_dices, ref int number, string response)
    {
        Console.Write("\nNow please enter the number you want to play with : ");
        number = 0;
        while (number < nb_dices || number > nb_dices * 6)
        {
            response = Console.ReadLine();
            int.TryParse(response, out number);
            if (number < nb_dices || number > nb_dices * 6)
                Console.Write("The number that will come out will be between " + nb_dices + " and " + nb_dices * 6 + " so please choose another one : ");
        }
    }


    static void intro(ref int bet, ref int number, int money, ref int nb_dices)
    {
        string response = null;

        intro_dices(money, ref nb_dices, response);
        intro_bet(money, ref bet, response);
        intro_number(nb_dices, ref number, response);
    }


    static bool wait_answer(string response, int money)
    {
        bool answer = false;

        while (!answer)
        {
            Console.Write("So now you have " + money + " dollars, do you want to continue ? [y/n] : ");
            response = Console.ReadLine();
            if (response[0] == 'n')
                return (false);
            if (response[0] == 'y')
                answer = true;
        }
        return (answer);
    }


    static void wait_bet(ref int bet, string response, int money)
    {
        bet = 0;
        while (bet > money || bet == 0)
        {
            Console.Write("Please enter the amount you want to bet : ");
            response = Console.ReadLine();
            int.TryParse(response, out bet);
            if (bet > money)
                Console.WriteLine("You can't bet this amount, you don't have enough money !");
            if (bet == 0)
                Console.WriteLine("You cant bet 0 dollars come on !");
        }
    }


    static void wait_number(ref int number, int nb_dices, string response)
    {
        number = 0;
        while (number < nb_dices || number > nb_dices * 6)
        {
            Console.Write("\nNow please enter the number you want to play with : ");
            response = Console.ReadLine();
            int.TryParse(response, out number);
            if (number < nb_dices || number > nb_dices * 6)
                Console.Write("The number that will come out will be between " + nb_dices + " and " + nb_dices * 6 + " so please choose another one : ");
        }
    }


    static bool get_bet(ref int bet, ref int number, int money, int nb_dices)
    {
        string response = null;

        if (money <= 0)
            return (false);
        if (!wait_answer(response, money))
            return (false);
        wait_bet(ref bet, response, money);
        wait_number(ref number, nb_dices, response);
        return (true);
    }


    static void bet_result(int total, int number, int bet, ref int money)
    {
        if (number == total)
            {    
                money = money + bet;
                Console.WriteLine("Yes it's " + number + " ! So you earned " + bet + " dollars !\n");
            }
            else
            {
                money = money - bet;
                Console.WriteLine("Oh no ! It was " + total + " so you loose " + bet + " dollars !\n");
            }
    }


    static void play_dice(int nb_dices, ref int total)
    {
        Random rand = new Random();
        int dice = 0;

        if (nb_dices > 1)
            {
                for (int i = 0; i < nb_dices; i++)
                {
                    dice = rand.Next(6) + 1;
                    total = total + dice;
                    draw_dice(dice);
                }
            }
            else
            {
                total = rand.Next(6) + 1;
                draw_dice(total);
            }
    }


    static void end_result(int money)
    {
        if (money > 0)
            Console.WriteLine("You leave the game with " + money + " dollars ! Thanks for playing !");
        else
            Console.WriteLine("You have lost all your money :(");
    }


    static void wait_result(int bet, int number, ref int total)
    {
        Console.WriteLine("\nLet's see if you can earn " + bet + " dollars with the number " + number + "...");
        Console.WriteLine("And the result is ...");
        total = 0;
    }


    static void Main()
    {
        int money = 50;
        int bet = 0;
        int number = 0;
        int nb_dices = 0;
        int total = 0;

        intro(ref bet, ref number, money, ref nb_dices);
        while (money >= 0)
        {
            wait_result(bet, number, ref total);
            play_dice(nb_dices, ref total);            
            bet_result(total, number, bet, ref money);
            if (!get_bet(ref bet, ref number, money, nb_dices))
                break;
        }
        end_result(money);
        Console.Read();
    }
}