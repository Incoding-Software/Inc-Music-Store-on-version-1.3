namespace IncMusicStore.Domain
{
    using Incoding.CQRS;

    public class FormatToMoneyQuery : QueryBase<string>
    {
        readonly decimal value;

        public FormatToMoneyQuery(decimal value)
        {
            this.value = value;
        }

        protected override string ExecuteResult()
        {
            return this.value.ToString("C");
        }
    }
}