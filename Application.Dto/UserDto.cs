using System;
using System.Collections.Generic;

namespace Application.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Base64Image { get; set; }
        public string ImgName { get; set; }
        public string KeyName { get; set; }
        public string ReferenceCode { get; set; }
        public string InvitedCode { get; set; }
        public bool State { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string ResidenceCity { get; set; }
        public DateTime BirthdayDate { get; set; }
        public int Indicador { get; set; }
        public UserPointDto UserPoint { get; set; }
        //public int? Rol { get; set; }
        //public List<UserRolDto> RolList { get; set; }
    }
}