﻿using System;
using System.Text;
using System.Collections.Generic;
using Novel;
namespace NovelLang
{
	using static Console;
	/// <summary>
	/// Entry point.
	/// </summary>
	public static class EntryPoint
	{
		const string Name = "Novel Script REPL";
		const string Version = "ver1.0.0-pre-20171126";
		const string Copyright = "(C)2017 Xeltica";

		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		static void Main(string[] args)
		{
			WriteLine($"{Name} {Version}\n{Copyright}\n------------");
			// バッファ
			var codeList = new List<string>();
			string buf;
			// .quit と入力したら，終了する
			WriteLine(".quit: 終了\n.eof: スクリプトの終わり\n.undo: 前の行を元に戻す");
			while (true)
			{
				Write("> ");
				buf = ReadLine();
				switch (buf.ToLower())
				{
					// 閉じる
					case ".quit":
						// 終える
						WriteLine("さようなら．");
						return;
					// 一行戻す
					case ".undo":
						// 例外処理してあげる
						if (codeList.Count == 0)
						{
							WriteLine("no text in buffer.");
							continue;
						}
						// 削除
						codeList.RemoveAt(codeList.Count - 1);
						break;
					// 入力終わり
					case ".eof":
						// テキストを連結して，スクリプトコードにする
						var code = string.Join("\n", codeList);
						// バッファを空にする
						codeList.Clear();
						NovelRuntime.Run(code);
						break;
					default:
						// テキストを積む
						codeList.Add(buf);
						break;
				}
			}
		}
	}
}