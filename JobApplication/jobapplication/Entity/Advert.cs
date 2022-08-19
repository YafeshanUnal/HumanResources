using System.ComponentModel.DataAnnotations;

namespace jobapplication.Entity{

    // * İş verenlerin departmanı, konumu, tecrübe düzeyine, iş ünvanı, açıklamasını ve diğer detayları belirterek ilan açabileceği bir portal,
    public class Advert{

        [Key]

        public int AdvertId { get; set; }
        public string Department { get; set; }

        public string Location { get; set; }

        public int Experience { get; set; }

        public string workTitle { get; set; }

        public string Description { get; set; }

        public string Detail { get; set; }

        public int EmployerId { get; set; }
        public int WorkerId { get; set; }







    }
}