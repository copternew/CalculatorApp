using System.ComponentModel.DataAnnotations;

public class CalculatorModel
{
    [Required(ErrorMessage = "X is required")]
    public decimal X { get; set; }

    [Required(ErrorMessage = "Y is required")]
    public decimal Y { get; set; }
    [Required(ErrorMessage = "Operator is required")]
    public string Operator { get; set; }
    public double? Result { get; set; }
}
