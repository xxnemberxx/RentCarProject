using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public static class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach(var logic in logics)
            {
                if(!logic.Success)
                {
                    return logic;
                }
            }

            return new SuccessResult();
        }

        public static bool CheckRules(this IResult result)
        {
            if (result != null)
            {
                return false;
            }

            return true;
        }
    }
}
