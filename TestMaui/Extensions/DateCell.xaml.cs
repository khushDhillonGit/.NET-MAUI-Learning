namespace TestMaui.Extensions;

public partial class DateCell : ViewCell
{
	public static readonly BindableProperty LabelProperty = BindableProperty.Create(nameof(Label), typeof(string), typeof(DateCell));
	public string Label { get => (string)GetValue(LabelProperty); set => SetValue(LabelProperty, value); }
	public DateCell()
	{
		InitializeComponent();
		BindingContext = this;
	}
}