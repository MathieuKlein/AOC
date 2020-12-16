namespace D16TicketTranslation
{
    public class WrongTicket
    {
        public WrongTicket(Ticket ticket, int wrongValue)
        {
            Ticket = ticket;
            WrongValue = wrongValue;
        }

        public Ticket Ticket { get; }
        public int WrongValue { get; }
    }
}