using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Text.Json;
//using ThreadNetwork;
using Newtonsoft.Json;

namespace CollectionViews;

public partial class MyCollection : ContentPage
{

    public class Fruit
    {
        public string FruitName { get; set; }
        public string FruitDescription { get; set; }
    }

    ObservableCollection<Fruit> fruits = new ObservableCollection<Fruit>();
    public ObservableCollection<Fruit> Fruits { get { return fruits; } }

    ObservableCollection<TodoItem> todoitems = new ObservableCollection<TodoItem>();
    public ObservableCollection<TodoItem> ToDoItems { get { return todoitems; } }


    public MyCollection()
	{
		InitializeComponent();

        fruits.Add(new Fruit() { FruitName = "Apple", FruitDescription = "An apple is an edible fruit produced by an apple tree (Malus domestica)." });
        fruits.Add(new Fruit() { FruitName = "Orange", FruitDescription = "The orange is the fruit of various citrus species in the family Rutaceae." });
        fruits.Add(new Fruit() { FruitName = "Banana", FruitDescription = "A long curved fruit with soft pulpy flesh and yellow skin when ripe." });
        fruits.Add(new Fruit() { FruitName = "Grape", FruitDescription = "A berry growing in clusters on a grapevine, eaten as fruit and used in making wine." });
        fruits.Add(new Fruit() { FruitName = "Mango", FruitDescription = "A mango is an edible stone fruit produced by the tropical tree Mangifera indica." });
        //collectionView.ItemsSource = fruits;
        getValues();
        collectionView.ItemsSource = todoitems;
    }

    public class TodoItem
    {
        public string id { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        //public bool Done { get; set; }
    }

    private const string url = "https://63e925ecb120461c6bebf878.mockapi.io/api/items/users";
    private HttpClient _Client = new HttpClient();
    //private ObservableCollection<User> userCollection;

    private async void getValues()
    {
        HttpClient client = new HttpClient();

        var httpResponse = _Client.GetAsync(url).Result;

        var contents = await httpResponse.Content.ReadAsStringAsync();
        Debug.WriteLine(contents);

        httpResponse.EnsureSuccessStatusCode();
        var responseBody = await httpResponse.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<TodoItem>>(responseBody);

        foreach (var i in result)
        {
            //fruits.Add(new Fruit() { FruitName = "Apple", FruitDescription = "An apple is an edible fruit produced by an apple tree (Malus domestica)." });
            todoitems.Add(new TodoItem() {name = i.name, avatar = i.avatar});
            
           Debug.WriteLine(i.name);
           Debug.WriteLine(i.avatar);
        }

        //    var objResponse1 =
        //JsonConvert.DeserializeObject<List<RetrieveMultipleResponse>>(JsonStr);

        //using (Stream s = client.GetStreamAsync(url).Result)
        //using (StreamReader sr = new StreamReader(s))
        //using (JsonReader reader = new JsonTextReader(sr))
        //{
        //    Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
        //    var Jsonobject = JsonConvert.DeserializeObject<PathWayWrapper>(json);

        //    // read the json from a stream
        //    // json size doesn't matter because only a small piece is read at a time from the HTTP request
        //    //Person p = serializer.Deserialize<Person>(reader);
        //    //TodoItem it = serializer.Deserialize<TodoItem>(reader);
        //    List<string> it = serializer.Deserialize<List<String>>(reader);
        //    Debug.WriteLine(serializer);
        //}


        //Debug.WriteLine(httpResponse);
        //Debug.WriteLine(httpResponse);

        ////string json = client.GetStringAsync("http://www.test.com/large.json").Result;

        //Person p = JsonConvert.DeserializeObject<Person>(json);

        //if (httpResponse.IsSuccessStatusCode)
        //{
        //    Response responseData = JsonConvert.DeserializeObject<Response>(await httpResponse.Content.ReadAsStringAsync());
        //    userCollection = new ObservableCollection<User>(responseData.Users);
        //    User_List.ItemsSource = userCollection;
        //}
        //return getValues();
    }






}