using System;

namespace HeadsNTails
{
    class HeadsNTails
    {
        static void Main()
        {
            var parsedInput = ParseInput();
            var countedTosses = CountHeadsTails(parsedInput);
            GetWinningTosses(countedTosses);
        }

        static string ParseInput()
        {
            string tosses = Console.ReadLine();

            if (String.IsNullOrEmpty(tosses))
            {
                throw new ArgumentException("Input is invalid - either null or empty");
            }

            tosses = tosses.Replace(" ", "");
            tosses = tosses.Replace(",", "");
            tosses = tosses.Replace("t", "t".ToUpper());
            tosses = tosses.Replace("h", "h".ToUpper());

            return tosses;
        }

        static string increaseCollectionWithOneElement(string tosses)
        {
            if (tosses[tosses.Length - 1] == 'T')
            {
                tosses = tosses + 'H';
            }
            else
            {
                tosses = tosses + 'T';
            }

            return tosses;
        }

        static CounterHeadsTails CountHeadsTails(string tosses)
        {
            byte counterHeads = 0;
            byte counterTails = 0;
            byte maxCounterHeads = 0;
            byte maxCounterTails = 0;

            tosses = increaseCollectionWithOneElement(tosses);
            

            for (int i = 0; i < tosses.Length - 1; i++)
            {
                
                if (tosses[i] == 'H')
                {
                    counterHeads++;

                    if (tosses[i+1] == 'T')
                    {
                        if (maxCounterHeads < counterHeads)
                        {
                            maxCounterHeads = counterHeads;
                        }

                        counterHeads = 0;
                    }
                }

                if (tosses[i] == 'T')
                {
                    counterTails++;

                    if (tosses[i + 1] == 'H')
                    {
                        if (maxCounterTails < counterTails)
                        {
                            maxCounterTails = counterTails;
                        }

                        counterTails = 0;
                    }
                }
            }

            CounterHeadsTails countedHeadAndTails = new CounterHeadsTails(maxCounterHeads, maxCounterTails);

            return countedHeadAndTails;
        }

        static void GetWinningTosses(CounterHeadsTails countedHeadAndTails)
        {

            if (countedHeadAndTails.Heads > countedHeadAndTails.Tails)
            {
                Console.WriteLine("H wins!");
            }

            if (countedHeadAndTails.Tails > countedHeadAndTails.Heads)
            {
                Console.WriteLine("T wins!");
            }

            if (countedHeadAndTails.Heads == countedHeadAndTails.Tails)
            {
                Console.WriteLine("Draw!");
            }

        }   
    }

    class CounterHeadsTails
    {
        public CounterHeadsTails(int headsCount, int tailsCount)
        {
            this.Heads = headsCount;
            this.Tails = tailsCount;
        }

        public int Heads { get; set; }

        public int Tails { get; set; }
    }
}
