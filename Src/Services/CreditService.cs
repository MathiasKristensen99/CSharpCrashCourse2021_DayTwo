using System;
using System.ComponentModel.Design;
using CrashCourse2021ExercisesDayTwo.Models;

namespace CrashCourse2021ExercisesDayTwo.Services
{
    //This is the only Class where you should change code!! :)
    public class CreditService
    {
        private Credit credit;

        public CreditService()
        {
            credit = new Credit { Value = 0, MaxAllowed = 10000d};
        }

        internal double CurrentCreditValue()
        {
            return credit.Value;
        }

        internal void AddCredit(double valueToAdd)
        {
            if (valueToAdd < 0)
            {
                throw new ArgumentException(Constants.CreditToAddMustBeZeroOrMoreException);
            }
            if (credit.MaxAllowed >= credit.Value + valueToAdd)
            {
                credit.Value = (credit.Value + valueToAdd);
            }
            else
            {
                throw new ArgumentException(Constants.CreditCannotExceedMaxValueException);
            }
            
        }

        internal void RemoveCredit(double valueToRemove)
        {
            if (valueToRemove < 0)
            {
                throw new ArgumentException(Constants.CreditToRemoveMustBeZeroOrMoreException);
            }
            if (credit.Value - valueToRemove >= 0)
            {
                credit.Value = (credit.Value - valueToRemove);
            }
            else
            {
                throw new ArgumentException(Constants.CreditCannotBeLessThenZeroException);
            }
        }

        internal double CurrentMaxAllowedValue()
        {
            return credit.MaxAllowed;
        }

        internal void SetMaxAllowedValue(double maxValue)
        {
            if (maxValue > 0)
            {
                credit.MaxAllowed = maxValue;
            }
            if (maxValue < 0)
            {
                throw new ArgumentException(Constants.CreditMaxValueMustBeAboveZeroException);
            }
            else if (maxValue > 1000_000_000)
            {
                throw new ArgumentException(Constants.CreditMaxValueCannotBeAboveABillionException);
            }
        }
    }
}
