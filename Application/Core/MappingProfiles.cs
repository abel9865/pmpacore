using AutoMapper;
using Domain;
using DTOs;

namespace Application.Core
{
    public class MappingProfiles : AutoMapper.Profile
    {
        public MappingProfiles()
        {
            CreateMap<ClientProject, ClientProject>();
            CreateMap<Role, Role>();
            //Tell autoMapper to map RoleDto from Role and alo map RegisterUsers property from the UserRoles property
            CreateMap<Role, RoleDto>()
            .ForMember(x=>x.ClientId, u=>u.MapFrom(s=>s.Project.ClientId))
            .ForMember(x => x.RegisteredUsers, u => u.MapFrom(s => s.UserRoles));
            //Tell outoMapper how to map RegisterUserDto from UserRole
            CreateMap<UserRole, RegisteredUserDto>()
            .ForMember(x => x.FirstName, u => u.MapFrom(s => s.User.FirstName))
              .ForMember(x => x.LastName, u => u.MapFrom(s => s.User.LastName))
                .ForMember(x => x.Active, u => u.MapFrom(s => s.User.Active))
                  .ForMember(x => x.Address, u => u.MapFrom(s => s.User.Address1))
                    .ForMember(x => x.City, u => u.MapFrom(s => s.User.City))
                      .ForMember(x => x.State, u => u.MapFrom(s => s.User.State))
                        .ForMember(x => x.ZipCode, u => u.MapFrom(s => s.User.Zip))
                          .ForMember(x => x.Country, u => u.MapFrom(s => s.User.Country))
                            .ForMember(x => x.PhoneNumber, u => u.MapFrom(s => s.User.Phone))
                              .ForMember(x => x.ClientId, u => u.MapFrom(s => s.User.ClientId))
                                .ForMember(x => x.Email, u => u.MapFrom(s => s.User.Email))
                                  .ForMember(x => x.IsAdmin, u => u.MapFrom(s => s.User.IsAdmin))

                                      .ForMember(x => x.ProfileImage, u => u.MapFrom(s => s.User.ProfileImage))
                                        .ForMember(x => x.ProfilePath, u => u.MapFrom(s => s.User.ProfilePath))
                                          .ForMember(x => x.SysTimeOffset, u => u.MapFrom(s => s.User.SysTimeOffset))
                                            .ForMember(x => x.SysTimeZone, u => u.MapFrom(s => s.User.SysTimeZone))
                                              .ForMember(x => x.UserId, u => u.MapFrom(s => s.User.Id));

        }
    }
}