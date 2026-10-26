using System;

namespace EShopApp.Models.Enums;

public static class OrderStatusExtensions
{
    public static string ToText(this OrderStatus status)
    {
        return status switch
        {
            OrderStatus.Pending => "Hazırlanıyor",
            OrderStatus.Shipped => "Kargoda",
            OrderStatus.Delivered => "Teslim Edildi",
            OrderStatus.Cancelled => "İptal Edildi",
            _ => status.ToString()
        };
    }

    public static string ToBadgeClass(this OrderStatus status)
    {
        return status switch
        {
            OrderStatus.Pending => "bg-warning text-dark",
            OrderStatus.Shipped => "bg-info text-dark",
            OrderStatus.Delivered => "bg-success",
            OrderStatus.Cancelled => "bg-secondary",
            _ => "bg-light text-dark"
        };
    }
}
