using System;
using System.Threading.Tasks;

using R5T.Magyar;

using R5T.D0100;
using R5T.T0095;


namespace System
{
    public static class IFileBasedRepositoryExtensions
    {
        /// <summary>
        /// Performs <see cref="IFileBasedRepository.Save"/> upon disposal to ensure modifications are saved.
        /// </summary>
        public static async Task<OnDisposeAction> GetModificationContext(this IFileBasedRepository fileBasedRepository)
        {
            await fileBasedRepository.Load();

            var output = new OnDisposeAction(() => fileBasedRepository.Save());
            return output;
        }

        /// <summary>
        /// Performs no action upon disposal to ensure modifications are *not* saved.
        /// </summary>
        public static async Task<OnDisposeAction> GetQueryContext(this IFileBasedRepository fileBasedRepository)
        {
            await fileBasedRepository.Load();

            var output = new OnDisposeAction(ActionHelper.GetDoNothingAsynchronousAction());
            return output;
        }
    }
}