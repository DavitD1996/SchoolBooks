using SchoolBooks.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolBooks.Services.DTO.Pupils
{
    public class PupilDtoRegistration
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Class { get; set; }
        public string SchoolName { get; set; }
        public static Pupil GetPupilEntityFromDto(PupilDtoRegistration pupilDto)
        {
            return new Pupil(pupilDto.Id)
            {
                Name = pupilDto.Name,
                SurName = pupilDto.SurName,
                Class = pupilDto.Class,
                SchoolName = pupilDto.SchoolName,
            };
        }

    }
}
