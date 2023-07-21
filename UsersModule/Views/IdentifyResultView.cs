using MTFTest.UsersModule.Models;

namespace MTFTest.UsersModule.Views
{
    public class IdentifyResultView
    {
        // default there is N/A (IdentifyStatus(0)).
        public IdentifyStatus Status { get; private set; } = default!;

        public string? Message { get; private set; }

        public IdentifyResultView(IdentifyStatus status, string? message = default)
        {
            Status = status;
            Message = message;
        }
    }
}
