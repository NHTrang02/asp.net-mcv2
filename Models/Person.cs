using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Models {

    public class Person {
        public int Id{get; set;}
        [Required]
        public string FirstName{get; set;}
        [Required]
        public string LastName{get; set;}
        [Required]
        public string Gender {get; set;}
        [Required]
        public DateTime DateOfBirth {get;set;}
        [RegularExpression("^\\d{9,}$", ErrorMessage ="Phone number is not valid")]
        public string PhoneNumber {get;set;}
        [EmailAddress]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage ="E-mail is not valid")]
        public string Email {get;set;}
         public string BirthPlace {get;set;}
         public int Age {
             get { return calcAge();}
            set {}
         }
         public int calcAge() {
             int a = 0;
             int years = DateTime.Now.Year - DateOfBirth.Year;
             int month = DateTime.Now.Month - DateOfBirth.Month;
             int days = DateTime.Now.Day - DateOfBirth.Day;
            if((days == 0 && month == 0)|| (month > 0)){
                a = 1;
            }
            return years + a;
         }
        public string FullName => $"{LastName} {FirstName}";
        public bool IsGraduated {get;set;}
        public int CaculateAge(){
            return int.Parse(DateTime.Now.ToString("yyyyMMdd")) - int.Parse(DateOfBirth.ToString("yyyyMMdd"));
        }
        
        }
}