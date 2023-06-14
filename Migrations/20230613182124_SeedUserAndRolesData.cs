using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

#nullable disable

namespace CampingApp.Migrations
{
    public partial class SeedUserAndRolesData : Migration
    {
        const string ADMIN_ROLE_GUID = "1ebc5831-55b1-4b47-bf03-06870604f614";
        const string SM_ROLE_GUID = "aa9b2fdf-7da7-4cb5-946b-6cf2f5817038";
        const string TL_ROLE_GUID = "465db437-dd18-4822-af44-1f0ee5064862";
        const string SR_ROLE_GUID = "bbe7b7e8-af66-466a-81cf-a252a2db12eb";

        const string ADMIN_USER_GUID = "f63e647f-39c7-4217-86c9-111959cca4d9";
        const string SM_USER_GUID = "413ba115-d954-4a44-8de6-36a4413ca8f9s";
        const string TL_USER_GUID = "2d1299a3-e922-43e6-aa07-f071d6082bf1";
        const string SR1_USER_GUID = "7baefb9e-e3db-4c10-b6e4-5177a50dfc88";
        const string SR2_USER_GUID = "85e387c3-a889-44c9-aee0-202eb83bbb2c";
        const string SR3_USER_GUID = "2584b502-dd43-4b49-b66b-e47c46d2ad45";
        const string SR4_USER_GUID = "7433d390-6b26-467c-ba46-4fcead043faa";


        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<IdentityUser>();

            var passwordHash = hasher.HashPassword(null, "Password1!");

            AddUser(migrationBuilder, "admin@oexl.com", passwordHash, ADMIN_USER_GUID);

            AddUser(migrationBuilder, "bob.jones@oexl.com", passwordHash, SM_USER_GUID);

            AddUser(migrationBuilder, "henry.andrews@oexl.com", passwordHash, TL_USER_GUID);

            AddUser(migrationBuilder, "olivia.mills@oexl.com", passwordHash, SR1_USER_GUID);
            AddUser(migrationBuilder, "noah.robinson@oexl.com", passwordHash, SR2_USER_GUID);
            AddUser(migrationBuilder, "benjamin.lucas@oexl.com", passwordHash, SR3_USER_GUID);
            AddUser(migrationBuilder, "sarah.henderson@oexl.com", passwordHash, SR4_USER_GUID);

            AddRole(migrationBuilder, "Admin", ADMIN_ROLE_GUID);
            AddRole(migrationBuilder, "SM", SM_ROLE_GUID);
            AddRole(migrationBuilder, "TL", TL_ROLE_GUID);
            AddRole(migrationBuilder, "SR", SR_ROLE_GUID);

            AddUserToRole(migrationBuilder, ADMIN_USER_GUID, ADMIN_ROLE_GUID);
            AddUserToRole(migrationBuilder, SM_USER_GUID, SM_ROLE_GUID);

            AddUserToRole(migrationBuilder, TL_USER_GUID, TL_ROLE_GUID);
            AddUserToRole(migrationBuilder, SR1_USER_GUID, SR_ROLE_GUID);
            AddUserToRole(migrationBuilder, SR2_USER_GUID, SR_ROLE_GUID);
            AddUserToRole(migrationBuilder, SR3_USER_GUID, SR_ROLE_GUID);
            AddUserToRole(migrationBuilder, SR4_USER_GUID, SR_ROLE_GUID);
        }
        private void AddUser(MigrationBuilder migrationBuilder, string email, string passwordHash, string userGuid)
        {
            StringBuilder sb = new StringBuilder();

            string emailCaps = email.ToUpper();

            sb.AppendLine("INSERT INTO AspNetUsers(Id, UserName, NormalizedUserName,Email,EmailConfirmed,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled,AccessFailedCount,NormalizedEmail,PasswordHash,SecurityStamp)");
            sb.AppendLine("VALUES(");
            sb.AppendLine($"'{userGuid}'");
            sb.AppendLine($",'{email}'");
            sb.AppendLine($",'{emailCaps}'");
            sb.AppendLine($",'{email}'");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine($",'{emailCaps}'");
            sb.AppendLine($", '{passwordHash}'");
            sb.AppendLine(", ''");
            sb.AppendLine(")");

            migrationBuilder.Sql(sb.ToString());
        }
        private void AddRole(MigrationBuilder migrationBuilder, string roleName, string roleGuid)
        {
            string roleNameCaps = roleName.ToUpper();

            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{roleGuid}','{roleName}','{roleNameCaps}')");


        }

        private void AddUserToRole(MigrationBuilder migrationBuilder, string userGuid, string roleGuid)
        {
            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES ('{userGuid}','{roleGuid}')");


        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            RemoveUser(migrationBuilder, ADMIN_USER_GUID, ADMIN_ROLE_GUID);
            RemoveUser(migrationBuilder, SM_USER_GUID, SM_ROLE_GUID);
            RemoveUser(migrationBuilder, TL_USER_GUID, TL_ROLE_GUID);
            RemoveUser(migrationBuilder, SR1_USER_GUID, SR_ROLE_GUID);
            RemoveUser(migrationBuilder, SR2_USER_GUID, SR_ROLE_GUID);
            RemoveUser(migrationBuilder, SR3_USER_GUID, SR_ROLE_GUID);
            RemoveUser(migrationBuilder, SR4_USER_GUID, SR_ROLE_GUID);

            RemoveRole(migrationBuilder, ADMIN_ROLE_GUID);
            RemoveRole(migrationBuilder, SM_ROLE_GUID);
            RemoveRole(migrationBuilder, TL_ROLE_GUID);
            RemoveRole(migrationBuilder, SR_ROLE_GUID);
        }
        private void RemoveUser(MigrationBuilder migrationBuilder, string userGuid, string roleGuid)
        {
            migrationBuilder.Sql($"DELETE FROM AspNetUserRoles WHERE UserId = '{userGuid}' AND RoleId = '{roleGuid}'");

            migrationBuilder.Sql($"DELETE FROM AspNetUsers WHERE Id = '{userGuid}'");
        }
        private void RemoveRole(MigrationBuilder migrationBuilder, string roleGuid)
        {
            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id = '{roleGuid}'");
        }
    }
}