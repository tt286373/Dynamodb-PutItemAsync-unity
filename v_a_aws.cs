using UnityEngine;
using System.Collections;

using Amazon.DynamoDBv2.DataModel;
using System.Collections.Generic;
using Amazon.DynamoDBv2;

using UnityEngine.UI;
using Amazon;
using Amazon.DynamoDBv2.DocumentModel;

using System;
using System.Threading;
using Amazon.Runtime.Internal;
using Amazon.Util;
using Amazon.DynamoDBv2.Model;

namespace AWSSDK.Examples
{
public class v_a_aws : DynamoDbBaseExample {

		private IAmazonDynamoDB _client;
		private DynamoDBContext _context;

		public Text resultText;
		//public Button back;
		public Button createOperation;
		//public Button updateOperation;
		//public Button deleteOperation;
		private static Table roomscoreTable;
		private static Table moreTable;

		private static int cc;
		private static int cc2;
		int bookID = 1001;

		private DynamoDBContext Context
		{
			get
			{
				if(_context == null)
					_context = new DynamoDBContext(_client);

				return _context;
			}
		}

		void Awake()
		{
			UnityInitializer.AttachToGameObject(this.gameObject);
			//createOperation.onClick.AddListener(PerformIns);//LoadSampleProducts()

			createOperation.onClick.AddListener(LoadTableListener);
			//loadTable.onClick.AddListener(LoadTableListener);
			//back.onClick.AddListener(BackListener);
			//createOperation.onClick.AddListener(PerformCreateOperation);
			//updateOperation.onClick.AddListener(PerformUpdateOperation);
			//deleteOperation.onClick.AddListener(PerformDeleteOperation);
			_client = Client;
		}

		private void PerformCreateOperation()
		{
			Book myBook = new Book
			{
				Id = bookID,
				Title = "object persistence-AWS SDK for.NET SDK-Book 1001",
				ISBN = "111-1111111001",
				BookAuthors = new List<string> { "Author 1", "Author 2" },
			};

			// Save the book.
			Context.SaveAsync(myBook,(result)=>{
				if(result.Exception == null)
					resultText.text += @"book saved";
			});
		}
		private void PerformIns()
		{
			/*  Demo for insert one item
			roomscore myScore = new roomscore
			{
				earthid = 0,
				iid = 0,
				score = 6,
				earthname = "xx",
				mainstars="1,11",
				mainstarsscore="7,4",
				mainstarsname="xxxx",

			};

			// Save the book.
			Context.SaveAsync(myScore,(result)=>{
				if(result.Exception == null)
					resultText.text += @"Score saved";
			});
*/
			globe.purplesc = new purples ();
			globe.purplesc = SaveLoad5.LoadData ();
		

		}

		void LoadTableListener ()
		{
			resultText.text = "**LoadTable*";
			
			Table.LoadTableAsync(_client,"roomscore",(loadTableResult)=>{
				if(loadTableResult.Exception != null)
				{
					resultText.text = " failed to load";
				}
				else
				{
					roomscoreTable = loadTableResult.Result;
					LoadSampleProducts();
				}
			});

			Table.LoadTableAsync(_client,"personmore",(loadTableResult)=>{
				if(loadTableResult.Exception != null)
				{
					resultText.text = " failed to load";
				}
				else
				{
					moreTable = loadTableResult.Result;
					Loadmore1();
					Loadmore2();
				}
			});



		}
		private static void LoadSampleProducts()
		{
			
			globe.purplesc = new purples ();
			globe.purplesc = SaveLoad5.LoadData ();
		

			cc = 0;
				for (int i = 0; i < globe.purplesc.score.Count; i++) {

					var bicycle5 = new Document ();

					bicycle5 ["earthid"] = globe.purplesc.score [i].earthid;
					bicycle5 ["iid"] = globe.purplesc.score [i].iid;
					bicycle5 ["score"] = globe.purplesc.score [i].score;
					bicycle5 ["earthname"] = globe.purplesc.score [i].earthname;


					bicycle5 ["mainstars"] = globe.purplesc.score [i].mainstars;
					bicycle5 ["mainstarsscore"] = globe.purplesc.score [i].mainstarsscore;
					bicycle5 ["mainstarsname"] = globe.purplesc.score [i].mainstarsname; 


					roomscoreTable.PutItemAsync (bicycle5, (r) => {
					  Loadcount();
					});//put one block

				}//for 144
				
		}//loadsample end

		private static void Loadcount(){

			cc = cc + 1;
			//resultText.text = @"saved= "+cc;
			print ("---loadcount-"+cc);
		}
		private static void Loadcount2(){

			cc2 = cc2 + 1;
		
			print ("---loadcount2-"+cc2);
		}

		private static void Loadmore1()
		{

			globe.purplesc = new purples ();
			globe.purplesc = SaveLoad5.LoadData ();
		

			cc = 0;
			for (int i = 0; i < globe.purplesc.fming.Count; i++) {//change

				var bicycle5 = new Document ();

				bicycle5 ["stype"] = globe.purplesc.fming [i].stype;//change
				bicycle5 ["ii"] = globe.purplesc.fming [i].ii; //change
				bicycle5 ["label"] = globe.purplesc.fming [i].label;//change


				moreTable.PutItemAsync (bicycle5, (r) => {
					Loadcount();
				
				});//put one block

			}//for 144



		}//loadsample end

	
		private static void Loadmore2()
		{

			globe.othersc = new others ();
			globe.othersc=Saveload2.LoadData ();

			cc2 = 0;
			for (int i = 0; i < globe.othersc.star5.Count; i++) { //change

				var bicycle5 = new Document ();

				bicycle5 ["stype"] = globe.othersc.star5 [i].stype;//change
				bicycle5 ["ii"] = globe.othersc.star5 [i].ii;//change
				bicycle5 ["label"] = globe.othersc.star5 [i].label; //change


				moreTable.PutItemAsync (bicycle5, (r) => {
					Loadcount2();

				});//put one block

			}//for 144
			

			for (int i = 0; i < globe.othersc.starup.Count; i++) { //change

				var bicycle5 = new Document ();

				bicycle5 ["stype"] = globe.othersc.starup [i].stype;//change
				bicycle5 ["ii"] = globe.othersc.starup [i].ii;//change
				bicycle5 ["label"] = globe.othersc.starup [i].label; //change


				moreTable.PutItemAsync (bicycle5, (r) => {
					Loadcount2();

				});//put one block

			}//for 144



		}//loadsample end





		private void PerformUpdateOperation()
		{
			// Retrieve the book. 
			Book bookRetrieved = null;
			Context.LoadAsync<Book>(bookID,(result)=>
				{
					if(result.Exception == null )
					{
						bookRetrieved = result.Result as Book;
						// Update few properties.
						bookRetrieved.ISBN = "222-2222221001";
						bookRetrieved.BookAuthors = new List<string> { " Author 1", "Author x" }; // Replace existing authors list with this.
						Context.SaveAsync<Book>(bookRetrieved,(res)=>
							{
								if(res.Exception == null)
									resultText.text += ("\nBook updated");
							});
					}
				});
		}

		private void PerformDeleteOperation()
		{
			// Delete the book.
			Context.DeleteAsync<Book>(bookID,(res)=>{
				if(res.Exception ==null)
				{
					Context.LoadAsync<Book>(bookID,(result)=>
						{
							Book deletedBook = result.Result;
							if(deletedBook==null)
								resultText.text += ("\nBook is deleted");
						});
				}
			});
		}
	}

	[DynamoDBTable("roomscore")]
	public class roomscore
	{
		[DynamoDBHashKey]   // Hash key.
		public int earthid { get; set; }
		[DynamoDBRangeKey]
		public int iid { get; set; }
		[DynamoDBProperty]
		public int score { get; set; }

		[DynamoDBProperty]
		public string earthname { get; set; }
		[DynamoDBProperty]
		public string mainstars { get; set; }

		[DynamoDBProperty]
		public string mainstarsscore { get; set; }
		[DynamoDBProperty]
		public string mainstarsname { get; set; }
	}

	[DynamoDBTable("personmore")]
	public class personmore
	{
		[DynamoDBHashKey]   // Hash key.
		public string stype { get; set; }
		[DynamoDBRangeKey]
		public int ii { get; set; }
		[DynamoDBProperty]
		public string label { get; set; }

	}


}
