using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.Models
{
    public class UserManagement
    {
        [Key]
        public int ?UserId { get; set; }

        [Required]
        public string ?Firstname { get; set; }

        [Required]
        public string ?Lastname { get; set; }

        [Required]
        public string ?EmailId { get; set; }

        [Required]
        public string ?Password { get; set; }

        [Required]
        public char ?UserRole { get; set; }
        [Required]
        public char ?IsActive { get; set; }

        public void setUserId(int UserId)
        {
            this.UserId = UserId;
        }
        public void setFirstname(string Firstname)
        {
            this.Firstname= Firstname;
        }

        public void setLastname(string Lastname)
        {
            this.Lastname = Lastname;
        }
        public void setEmailId(string EmailId)
        {
            this.EmailId = EmailId;
        }

        public void setPassword(string Password)
        {
            this.Password = Password;
        }

        public void setUserRole(char UserRole)
        {
            this.UserRole =UserRole ;
        }

        public void setIsActive(char IsActive)
        {
            this.IsActive = IsActive;
        }

        public int ?getUserId()
        {
            return this.UserId;
        }

        public string ?getFirstname()
        {
            return this.Firstname;
        }

        public string? getLastname()
        {
            return this.Lastname;
        }

        public string? getEmailId()
        {
            return this.EmailId;
        }

        public string ?getPassword()
        {
            return this.Password;
        }

        public char ?getUserRole()
        {
            return this.UserRole;
        }

        public char? getIsActive()
        {
            return this.IsActive;
        }







    }



}

