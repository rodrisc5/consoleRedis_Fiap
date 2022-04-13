// See https://aka.ms/new-console-template for more information




using StackExchange.Redis;

Console.WriteLine("Hello, World!");


string connectionString = "20.225.241.127";
var redis = ConnectionMultiplexer.Connect(connectionString);

var pub = redis.GetSubscriber();

var sub = redis.GetSubscriber();

var dbCont = redis.GetDatabase();



//sub.Subscribe("22net").OnMessage(
//    mbox =>
//    {
//        Console.WriteLine(mbox.Message);
//    });

sub.Subscribe("perguntas").OnMessage(
    mbox =>
    {
        Console.WriteLine(mbox.Message);

        var x = mbox.Message;


        //string a = "str123";
        string b = string.Empty;
        int val;
        bool exit = false; 

        for (int i = 0; i < x.ToString().Length; i++)
        {
            
            if (Char.IsDigit(x.ToString()[i]))
            {
                b += x.ToString()[i];
            }


            if (Char.IsDigit(x.ToString()[i]).Equals("+"))
                break;
        }


        if (b.Length > 0)
        {
            val = int.Parse(b);
            var resp = val + val;

            string[] soma = { "P1", "DevsIOBot", resp.ToString() };
            var hash = new HashSet<string>(soma);

            dbCont.HashSet("P1", "DevsIOBot", "5");
        }
           
        

       


    });


Console.ReadLine();