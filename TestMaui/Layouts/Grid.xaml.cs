namespace TestMaui;

public partial class GridPage : ContentPage
{
	public GridPage()
	{
		InitializeComponent();

		var grid = new Grid
		{
			RowSpacing = 10,
			ColumnSpacing = 20
		};

		grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100,GridUnitType.Absolute)});
		grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(200,GridUnitType.Absolute)});
		//grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100,GridUnitType.Absolute)});
		grid.ColumnDefinitions.Add(new ColumnDefinition { });

		Grid.SetColumn(new Label { Text = "Hello"},0);
		Grid.SetColumn(new Label { Text = "Yellow"},0);
	}
}