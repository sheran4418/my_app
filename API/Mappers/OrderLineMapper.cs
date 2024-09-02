using My_Api.Dtos.OrderHeader;
using My_Api.Dtos.OrderLine;
using My_Api.Models;

namespace My_Api.Mappers
{
    public static class OrderLineMapper
    {
        public static OrderLineDto to_orderLineDto(this OrderLine orderLineModel)
        {
            return new OrderLineDto
            {
               product_id = orderLineModel.product_id,
               qty = orderLineModel.qty,
               price = orderLineModel.price,
               Linestate = orderLineModel.Linestate,
               headerId = orderLineModel.headerId
               
               
            };
        }

        public static OrderLine CreateorderLineDto(this CreateLineDto createDto)
        {
          
                return new OrderLine
                {
                    product_id = createDto.product_id,
                    qty = createDto.qty,
                    price = createDto.price,
                    Linestate = createDto.Linestate,
                    headerId = createDto.headerId
                };
       
        }

        public static OrderLine UpdatlineDto(this OrderLineDto updateLineModel)
        {
            
                return new OrderLine
                {
                    product_id = updateLineModel.product_id,
                    qty = updateLineModel.qty,
                    price = updateLineModel.price,
                    Linestate = updateLineModel.Linestate,
                    headerId = updateLineModel.headerId
                };
   
        }
    }
}
