using RealEstateApp.Contracts.Dtos;

namespace RealEstateApp.Workspaces.Dtos;
    public class WorkspaceWithUsersDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserDto> Users { get; set; } = new();

        public WorkspaceWithUsersDto(int id, string name, List<UserDto> users)
        {
            Id = id;
            Name = name;
            Users = users;
        }
    }
