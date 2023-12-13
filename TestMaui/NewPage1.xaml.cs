using System.ComponentModel;

namespace TestMaui;

public partial class NewPage1 : ContentPage
{
	//public event PropertyChangedEventHandler PropertyChanged;

	private string _labelText = "1";
	public string LabelText { get { return _labelText; } set { if (value == _labelText) return; _labelText = value; OnPropertyChanged(nameof(LabelText));  } }

	public NewPage1() 
	{
		InitializeComponent();
		BindingContext = this;
		LabelText = "2";
	}

	//private void OnPropertyChanged(string callerName) 
	//{
	//	PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
	//}

}