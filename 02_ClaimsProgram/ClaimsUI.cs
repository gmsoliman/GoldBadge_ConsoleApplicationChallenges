using _02_ClaimsClassLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsProgram
{
    public class ClaimsUI
    {
        private readonly ClaimsRepo _claimsRepo = new ClaimsRepo();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Please enter the number of the option you'd like to select: \n" +
                    "1) See all claims \n" +
                    "2) Take care of next claim \n" +
                    "3) Enter a new claim \n" +
                    "4) Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        GetAllClaimsInQueue();
                        break;
                    case "2":
                        GetNextClaimInQueue();
                        break;
                    case "3":
                        AddAClaimToQueue();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                }
            }
        }
        private void GetAllClaimsInQueue()
        {
            Console.Clear();
            Queue<Claims> claimsQueue = _claimsRepo.GetAllClaims();
            foreach (Claims claim in claimsQueue)
            {
                Console.WriteLine($"{claim.ClaimID} {claim.ClaimType} {claim.Description} {claim.ClaimAmount} {claim.DateOfIncident} {claim.DateOfClaim} {claim.IsValid}");
            }
            Console.WriteLine("Press any key to return to the main menu.....");
            Console.ReadKey();
        }
        private void GetNextClaimInQueue()
        {
            Console.Clear();
            Claims nextInQueue = _claimsRepo.GetNextClaim();
            Console.WriteLine($"{nextInQueue.ClaimID} {nextInQueue.ClaimType} {nextInQueue.Description} {nextInQueue.ClaimAmount} {nextInQueue.DateOfIncident} {nextInQueue.DateOfClaim} {nextInQueue.IsValid}\n" +
                "Do you want to deal with this claim now(y/n)?");
            var userResponse = Console.ReadLine();
            switch (userResponse)
            {
                case "y":
                    DequeueClaim();
                    break;
                case "n":
                    Console.WriteLine($"Claim: {nextInQueue.ClaimID} was placed back in the queue. \n" +
                        "Press any key to return to the main menu.....");
                    Console.ReadKey();
                    break;
            }
            void DequeueClaim()
            {
                _claimsRepo.DeleteClaimFromQueue();
                Console.WriteLine($"Claim: {nextInQueue.ClaimID} was removed from the queue. \n" +
                    "Once you are finished with this claim, press any key to return to the main menu.....");
                Console.ReadKey();
            }
        }
        private void AddAClaimToQueue()
        {
            Claims newClaim = new Claims();
            Console.WriteLine("\nPlease enter a ClaimID number");
            newClaim.ClaimID = int.Parse(Console.ReadLine());

            Console.WriteLine("\nSelect a claim type: \n" +
                "1) Car \n" +
                "2) Home \n" +
                "3) Theft");
            string claimTypeResponse = Console.ReadLine();
            switch (claimTypeResponse)
            {
                case "1":
                    newClaim.ClaimType = TypeOfClaim.Car;
                    break;
                case "2":
                    newClaim.ClaimType = TypeOfClaim.Home;
                    break;
                case "3":
                    newClaim.ClaimType = TypeOfClaim.Theft;
                    break;
            }

            Console.WriteLine("\nPlease enter a description of the claim");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("\nPlease enter a claim amount");
            newClaim.ClaimAmount = double.Parse(Console.ReadLine());

            Console.WriteLine("\nPlease enter the date the incident occurred using the following format: MM/DD/YYYY");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("\nPlease enter the date the claim was made using the following format: MM/DD/YYYY");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            _claimsRepo.AddClaimToQueue(newClaim);
            Console.WriteLine($"Claim: { newClaim.ClaimID} was successfully added to the queue!\n" +
                "Press any key to return to the main menu.....");
            Console.ReadKey();
        }
        private void SeedContent()
        {
            var nextClaim = new Claims(1, TypeOfClaim.Car, "Car Accident on 464.", 400.00d, DateTime.Parse("04/25/2018"), DateTime.Parse("04/27/2018"));
            _claimsRepo.AddClaimToQueue(nextClaim);
        }

    }
}
