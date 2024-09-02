using Bn_API.Models;
using My_Api.Dtos.OrderHeader;
using My_Api.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace My_Api.Mappers
{
    public static class OrderHeaderMapper
    {
        public static OrderHeaderDto to_orderHeaderDto(this OrderHeader orderHeaderModel)
        {
            return new OrderHeaderDto
            {
                user_id = orderHeaderModel.user_id,
                date = orderHeaderModel.date,
                Headerstate = orderHeaderModel.Headerstate
            };
        }
        public static OrderHeader CreateHeadereDto(this CreateHeaderDto headerDto)
        {
            return new OrderHeader
            {
                user_id = headerDto.user_id,
                date = headerDto.date,
                Headerstate = headerDto.Headerstate
            };
        }

        public static UpdateOrderHeaderDto updateHeaderDto(this UpdateOrderHeaderDto updateheaderDto)
        {
            return new UpdateOrderHeaderDto
            {
                user_id = updateheaderDto.user_id,
                date = updateheaderDto.date,
                Headerstate = updateheaderDto.Headerstate
            };
        }
    }
}
