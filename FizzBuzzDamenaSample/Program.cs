using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzDamenaSample
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//FizzBuzz問題とは:
			//1からXまで数字を順に確認して、
			//3で割り切れるときは「Fizz」と出力する
			//5で割り切れるときは「Buzz」と出力する
			//両方で割り切れるときは「FizzBuzz」と出力する
			//それ以外は数字を出力する。
			//※それぞれの値はカンマ区切りで改行は行わないとする。

			//プログラムは動けばいい。と言う話ではありますが、
			//これは行き過ぎ！　なので、初心者は真似しないでね。
			//初心者がこれをコピーして提出すると、確実に「どこから盗用したの？」と詰められます。

			damenaFizzBuzz_OutPut008(50);

			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("[Enter]を押して終了してください。");
			Console.ReadLine();
		}

		/// <summary>
		/// 合わせて文字も String.Formatで置換する。（マイナス開始も対応）
		/// </summary>
		/// <param name="end">終わりの値</param>
		/// <param name="start">開始の値(初期値:1)</param>
		private static void damenaFizzBuzz_OutPut008(int end, int start = 1)
		{
			//改善点：
			//	不具合の可能性のあった、開始値をマイナスからスタートしても可能なように改善(endがstartよりも小さい不具合は残る)
			//問題点：
			//	全部に言えることですが・・・「拡張性がゼロ！（改修が発生した時に対応できない）」

			string[] repList15 = "{1}{2}_{0}_{0}_{1}_{0}_{2}_{1}_{0}_{0}_{1}_{2}_{0}_{1}_{0}_{0}".Split('_');

			Console.Write(
				String.Join(",",
					Enumerable.Range(start, end).Select((i) => String.Format(repList15[Math.Abs(i % (3 * 5))], i, "Fizz", "Buzz"))
				)
			);
		}

		/// <summary>
		/// 合わせて文字も String.Formatで置換する。ことで、重複していたものを
		/// </summary>
		/// <param name="end">終わりの値</param>
		/// <param name="start">開始の値(初期値:1)</param>
		private static void damenaFizzBuzz_OutPut007(int end, int start = 1)
		{
			//改善点：
			//	置換作業を、数値以外も反映する。


			string[] repList15 = "{1}{2}_{0}_{0}_{1}_{0}_{2}_{1}_{0}_{0}_{1}_{2}_{0}_{1}_{0}_{0}".Split('_');

			Console.Write(
				String.Join(",",
					Enumerable.Range(start, end).Select((i) => String.Format(repList15[i % (3 * 5)], i, "Fizz", "Buzz"))
				)
			);
		}

		/// <summary>
		/// 数値の置換のために、String.Formatを採用。
		/// </summary>
		/// <param name="end">終わりの値</param>
		/// <param name="start">開始の値(初期値:1)</param>
		private static void damenaFizzBuzz_OutPut006(int end, int start = 1)
		{
			//改善点：
			//	置換作業を、置換関数ではなく、String.Formatを採用する。（特殊な動きを減らす）

			string[] repList15 = "FizzBuzz_{0}_{0}_Fizz_{0}_Buzz_Fizz_{0}_{0}_Fizz_Buzz_{0}_Fizz_{0}_{0}".Split('_');

			Console.Write(
				String.Join(",",
					Enumerable.Range(start, end).Select((i) => String.Format(repList15[i % (3 * 5)], i))
				)
			);
		}

		/// <summary>
		/// 置換リストに「数字に置換」指示を書いて比較処理を完全削除
		/// </summary>
		/// <param name="end"></param>
		/// <param name="start"></param>
		private static void damenaFizzBuzz_OutPut005(int end, int start = 1)
		{
			//改善点：
			//	置換リストを、空白にしていたものを、「FizzBuzz」にない文字を採用することで「数値で置換」を行う。

			string[] repList15 = "FizzBuzz_N_N_Fizz_N_Buzz_Fizz_N_N_Fizz_Buzz_N_Fizz_N_N".Split('_');

			Console.Write(
				String.Join(",",
					Enumerable.Range(start, end).Select((i) => repList15[i % (3 * 5)].Replace("N", i.ToString()))
				)
			);
		}

		/// <summary>
		/// 置換リストをより短い記述に変更
		/// </summary>
		/// <param name="end">終わりの値</param>
		/// <param name="start">開始の値(初期値:1)</param>
		private static void damenaFizzBuzz_OutPut004(int end, int start = 1)
		{
			//改善点：
			//	置換リストを、短くするために文字列を分割する方法を採用。


			//項目は15の倍数になるので、15で割った余りを元に表にした
			//要素数と対応させるために0=15とする。
			string[] repList15 = "FizzBuzz___Fizz__Buzz_Fizz___Fizz_Buzz__Fizz__".Split('_');

			Console.Write(
				String.Join(",",
					Enumerable.Range(start, end)
						.Select((i) => {
							string s = repList15[i % (3 * 5)];
							return String.IsNullOrEmpty(s) ? i.ToString() : s;
						})
				)
			);
		}

		/// <summary>
		/// Enumerable.Rangeループを採用してfor文を削除
		/// </summary>
		/// <param name="end">終わりの値</param>
		/// <param name="start">開始の値(初期値:1)</param>
		private static void damenaFizzBuzz_OutPut003(int end, int start = 1)
		{
			//改善点：
			//	for文をEnumerable.Rangeに置き換えた。


			//項目は15の倍数になるので、15で割った余りを元に表にした
			//要素数と対応させるために0=15とする。
			string[] repList15 = new string[] { "FizzBuzz",
				null, null, "Fizz", null, "Buzz",
				"Fizz", null, null, "Fizz", "Buzz",
				null, "Fizz", null, null };

			Console.Write(
				String.Join(",",
					Enumerable.Range(start, end)
						.Select((i) => {
							string s = repList15[i % (3 * 5)];
							return String.IsNullOrEmpty(s) ? i.ToString() : s;
						})
				)
			);
		}

		/// <summary>
		/// 置換リストを作成してif分岐を軽減
		/// </summary>
		/// <param name="end">終わりの値</param>
		/// <param name="start">開始の値(初期値:1)</param>
		private static void damenaFizzBuzz_OutPut002(int end, int start = 1)
		{
			//改善点：
			//	事前に対応するリストを作成してif分岐を極力減らした。


			//項目は15の倍数になるので、15で割った余りを元に表にした
			//要素数と対応させるために0=15とする。
			string[] repList15 = new string[] { "FizzBuzz",
				null, null, "Fizz", null, "Buzz",
				"Fizz", null, null, "Fizz", "Buzz",
				null, "Fizz", null, null };

			for (int i = start; i <= end; i++)
			{
				string s = repList15[i % (3 * 5)];
				if (String.IsNullOrEmpty(s))
					s = i.ToString();

				Console.Write((i == start ? "" : ",") + s);
			}
		}

		/// <summary>
		/// 三項目式を覚えたばかりなのかな？
		/// </summary>
		/// <param name="end">終わりの値</param>
		/// <param name="start">開始の値(初期値:1)</param>
		private static void damenaFizzBuzz_OutPut001(int end, int start = 1)
		{
			//改善点：行数を減らしてみた。

			for (int i = start; i <= end; i++)
			{
				string s = (i % (3 * 5) == 0) ? "FizzBuzz" : (i % 3 == 0) ? "Buzz" : (i % 5 == 0) ? "Buzz" : i.ToString();
				Console.Write((i == start ? "" : ",") + s);
			}
		}

		/// <summary>
		/// ダメなと言う割には普通過ぎる！普通過ぎてダメ
		/// </summary>
		/// <param name="end">終わりの値</param>
		/// <param name="start">開始の値(初期値:1)</param>
		private static void damenaFizzBuzz_OutPut000(int end, int start = 1)
		{
			//ダメなポイント：
			//	素直に書きすぎてダメ。面白みがない

			for (int i = start; i <= end; i++)
			{
				string s = "";
				if (i % (3 * 5) == 0)
				{
					s = "FizzBuzz";
				}
				else if (i % 3 == 0)
				{
					s = "Fizz";
				}
				else if (i % 5 == 0)
				{
					s = "Buzz";
				}
				else
				{
					s = i.ToString();
				}

				Console.Write((i == start ? "" : ",") + s);
			}
		}



		//*** 下記はとりあえず私なりの実用的なFizzBuzzを考えてみましたが、やはり初心者向けではないです。 ****//



		/// <summary>
		/// 一旦本気で考えてみた（でも初心者がこれを提出したらたぶん怒られる）
		/// </summary>
		/// <param name="end">終わりの値</param>
		/// <param name="start">開始の値(初期値:1)</param>
		private static void fizzBuzz_OutPut000(int end, int start = 1)
		{
			//入れ替え
			if (end < start)
				(start, end) = (end, start);

			//リストを作成（各種の割り算と合計の割り算が一致している場合に全部入れるパターン各々異なるなら注意）
			var repList = new Dictionary<int, string>();
			repList.Add(3, "Fizz");
			repList.Add(5, "Buzz");

			List<string> result = new List<string>();

			for (int i = start; i <= end; i++)
			{
				string s = "";
				foreach(var key in repList.Keys)
				{
					if (i % key == 0)
						s += repList[key];
				}

				result.Add(String.IsNullOrEmpty(s) ? i.ToString() : s);
			}

			Console.Write(String.Join(",", result));
		}

		/// <summary>
		/// 一旦本気で考えてみた（でも初心者がこれを提出したらたぶん怒られる）
		/// </summary>
		/// <param name="end">終わりの値</param>
		/// <param name="start">開始の値(初期値:1)</param>
		private static void fizzBuzz_OutPut002(int end, int start = 1)
		{
			//入れ替え
			if (end < start)
				(start, end) = (end, start);

			//リストを作成（全パターン羅列版。優先順位の高いものを上に持っていくこと）
			var repList = new Dictionary<int, string>();
			repList.Add(3 * 5, "FizzBuzz");
			repList.Add(3, "Fizz");
			repList.Add(5, "Buzz");

			List<string> result = new List<string>();

			for (int i = start; i <= end; i++)
			{
				string s = "";
				foreach (var key in repList.Keys)
				{
					if (i % key == 0)
					{
						s = repList[key];
						break;
					}
				}

				result.Add(String.IsNullOrEmpty(s) ? i.ToString() : s);
			}

			Console.Write(String.Join(",", result));
		}

		/// <summary>
		/// 一旦本気で考えてみた（でも初心者がこれを提出したらたぶん怒られる）
		/// </summary>
		/// <param name="end">終わりの値</param>
		/// <param name="start">開始の値(初期値:1)</param>
		private static void fizzBuzz_OutPut003(int end, int start = 1)
		{
			//入れ替え
			if (end < start)
				(start, end) = (end, start);

			//リストを作成（全パターン羅列版。優先順位の高いものを上に持っていくこと）
			var repList = new Dictionary<int, string>();
			repList.Add(3 * 5, "FizzBuzz");
			repList.Add(3, "Fizz");
			repList.Add(5, "Buzz");

			Console.Write(
				String.Join(",",
					Enumerable.Range(start, end)
						.Select((i) => {
							var v = repList.Where((x) => i % x.Key == 0).Select((x) => x.Value);
							return v.Count() >= 1 ? v.First() : i.ToString();
						})
				)
			);
		}
	}
}
