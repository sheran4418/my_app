using My_Api.Dtos.OrderLine;
using My_Api.Dtos.Product;
using My_Api.Models;

namespace My_Api.Mappers
{
    public static class ProductsMapper
    {
        public static ProductDto to_productDto(this Products productModel)
        {
            return new ProductDto
            {
                prod_id = productModel.prod_id,
                prod_code = productModel.prod_code,
                prod_name = productModel.prod_name,
                prod_description = productModel.prod_description,
                prod_qty = productModel.prod_qty,
                prod_status = productModel.prod_status,
                prod_price = productModel.prod_price,
                prod_dateAdded = productModel.prod_dateAdded

            };
        }

        public static Products createProductDto(this CreateProductDto UpdateProductDto)
        {

            return new Products
            {
                prod_code = UpdateProductDto.prod_code,
                prod_name = UpdateProductDto.prod_name,
                prod_description = UpdateProductDto.prod_description,
                prod_qty = UpdateProductDto.prod_qty,
                prod_status = UpdateProductDto.prod_status,
                prod_price = UpdateProductDto.prod_price,
                prod_dateAdded = UpdateProductDto.prod_dateAdded
            };
        }

        public static UpdateProductDto UpdateProductDto(this UpdateProductDto updateproductModel)
        {

            return new UpdateProductDto
            {
                prod_code = updateproductModel.prod_code,
                prod_name = updateproductModel.prod_name,
                prod_description = updateproductModel.prod_description,
                prod_qty = updateproductModel.prod_qty,
                prod_status = updateproductModel.prod_status,
                prod_price = updateproductModel.prod_price,
                prod_dateAdded = updateproductModel.prod_dateAdded
            };
        }
    }
}
