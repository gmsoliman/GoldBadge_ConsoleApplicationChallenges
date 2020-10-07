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
            Console.WriteLine($"{"ClaimID",-5} {"Type",-10} {"Description",-30} {"Amount",-15} {"Date of Incident",-30} {"Date of Claim",-30} {"Is Valid",-5}\n");
            foreach (Claims claim in claimsQueue)
            {
                Console.WriteLine($"{claim.ClaimID,-5} {claim.ClaimType,-10} {claim.Description,-30} ${claim.ClaimAmount,-15} {claim.DateOfIncident,-30} {claim.DateOfClaim,-30} {claim.IsValid,-5}");
            }
            Console.WriteLine("\nPress any key to return to the main menu.....");
            Console.ReadKey();
        }
        private void GetNextClaimInQueue()
        {
            Console.Clear();
            Claims nextInQueue = _claimsRepo.GetNextClaim();
            Console.WriteLine($"{"ClaimID",-5} {"Type",-10} {"Description",-30} {"Amount",-15} {"Date of Incident",-30} {"Date of Claim",-30} {"Is Valid",-5}\n");
            Console.WriteLine($"{nextInQueue.ClaimID,-5} {nextInQueue.ClaimType,-10} {nextInQueue.Description,-30} ${nextInQueue.ClaimAmount,-15} {nextInQueue.DateOfIncident,-30} {nextInQueue.DateOfClaim,-30} {nextInQueue.IsValid,-5}\n" +
                "Do you want to deal with this claim now(y/n)?");
            var userResponse = Console.ReadLine();
            switch (userResponse)
            {
                case "y":
                    DequeueClaim();
                    break;
                case "n":
                    Console.WriteLine($"Claim ID:{nextInQueue.ClaimID} was placed back in the queue. \n" +
                        "Press any key to return to the main menu.....");
                    Console.ReadKey();
                    break;
            }
            void DequeueClaim()
            {
                _claimsRepo.DeleteClaimFromQueue();
                Console.WriteLine($"Claim ID:{nextInQueue.ClaimID} was removed from the queue. \n" +
                    "Once you are finished with this claim, press any key to return to the main menu.....");
                Console.ReadKey();
            }
        }
        private void AddAClaimToQueue()
        {
            Claims newClaim = new Claims();
            Console.WriteLine("\nPlease enter a ClaimID number");
            newClaim.ClaimID = int.Parse(Console.ReadLine());

            Console.WriteLine("\nSelect a claim type by entering the number of the corresponding type \n" +
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
