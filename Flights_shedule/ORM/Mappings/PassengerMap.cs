namespace ORM.Mappings
{
    using Domain;
    using FluentNHibernate.Mapping;

    /// <summary>
    /// Класс, описывающий правила отображения <see cref="Passenger"/> на таблицу и наоборот.
    /// </summary>
    internal class PassengerMap : ClassMap<Passenger>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="PassengerMap"/>.
        /// </summary>
        public PassengerMap()
        {
            this.Table("Passengers");

            this.Id(x => x.Id);

            this.Map(x => x.LastName);
            this.Map(x => x.FirstName);
            this.Map(x => x.Passport);

            this.References(x => x.Flight);
        }
    }
}
