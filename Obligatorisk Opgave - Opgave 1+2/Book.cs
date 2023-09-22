namespace Obligatorisk_Opgave___Opgave_1_2
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}={Id.ToString()}, {nameof(Title)}={Title}, {nameof(Price)}={Price.ToString()}";
        }

        public void Validate()
        {
            ValidateId();
            ValidateTitle();
            ValidatePrice();
        }
        public void ValidateId()
        {
            if (Id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id must be a possitive number, above zero.");
            }
        }
        public void ValidateTitle()
        {
            if (Title == null)
            {
                throw new ArgumentNullException("The book must have a title.");
            }

            if (Title.Length < 3)
            {
                throw new ArgumentOutOfRangeException("The title must be at least 3 characters long.");
            }
        }
        public void ValidatePrice()
        {
            if ((Price < 0) || (Price > 1200))
            {
                throw new ArgumentOutOfRangeException("The price must be between 0 and 1200.");
            }
        }
    }
}