using My_Api.Dtos.Product;
using My_Api.Dtos.Users;
using My_Api.Models;

namespace My_Api.Mappers
{
    public static class UserMapper
    {
        public static UsersDto to_usersDto(this Users userModel)
        {
            return new UsersDto
            {
                user_id = userModel.user_id,
                u_name = userModel.u_name,
                username = userModel.username,
                u_password = userModel.u_password,
                u_email = userModel.u_email,
                u_fname = userModel.u_fname,
                u_lname = userModel.u_lname,
                u_isactive = userModel.u_isactive

            };
        }


        public static Users to_CreateusersDto(this CreateUserDto CreateuserDto)
        {
            return new Users
            {
                u_name = CreateuserDto.u_name,
                username = CreateuserDto.username,
                u_password = CreateuserDto.u_password,
                u_email = CreateuserDto.u_email,
                u_fname = CreateuserDto.u_fname,
                u_lname = CreateuserDto.u_lname,
                u_isactive = CreateuserDto.u_isactive
            };
        }


        public static UpdateUserDto to_updateUsersDto(this UpdateUserDto UpdateuserModel)
        {
            return new UpdateUserDto
            {
                u_name = UpdateuserModel.u_name,
                username = UpdateuserModel.username,
                u_password = UpdateuserModel.u_password,
                u_email = UpdateuserModel.u_email,
                u_fname = UpdateuserModel.u_fname,
                u_lname = UpdateuserModel.u_lname,
                u_isactive = UpdateuserModel.u_isactive
            };
        }
    }
}
