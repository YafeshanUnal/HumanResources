using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace jobapplication.Entity
{


    /*
    ! Staj projeniz, iş ilanı iş başvuru platformu: İş verenin ve iş arayanın giriş yaptığı bir platform.
    ! İş verenlerin departmanı, konumu, tecrübe düzeyine, iş ünvanı, açıklamasını ve diğer detayları belirterek ilan açabileceği bir portal,
    ? hem iş arayanı hem de iş verenin genel sayfada tüm ilanları görüp konuma, tarihe, departmana, ve diğer detaylara gör filitreleyebildiği 
    ? iş arayanın başvurup iş verene bildiriminin düştüğü mini bir iş platformudur.*/

    public class Employer
    {

        [Key]
        public int EmployerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public string EmployerTitle { get; set; }

        public virtual List<Advert> Adverts { get; set; }

        
        

        
}
}