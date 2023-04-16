namespace Multitenant.Net6.API.ViewModel
{
    public class CreateCarCommandVM
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string VIN { get; set; }
        public string Transmission { get; set; }
        public string ExteriorColor { get; set; }
        public string InteriorColor { get; set; }
    }

    public class UpdateCarCommandVM: CreateCarCommandVM
    {
        public int Id { set; get; }
    }
}
