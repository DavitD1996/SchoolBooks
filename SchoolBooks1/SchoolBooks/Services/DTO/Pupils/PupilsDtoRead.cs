using SchoolBooks.Entities;

namespace SchoolBooks.Services.DTO.Pupils
{
    public class PupilsDtoRead
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Class { get; set; }
        public static PupilsDtoRead GetPupilDtoFromEntity(Pupil pupil)
        {
            return new PupilsDtoRead()
            {
                Id = pupil.Id,
                Name = pupil.Name,
                SurName = pupil.SurName,
                Class = pupil.Class,
            };
        }

    }
}
