using System;
using System.Windows;
namespace GunGiBoardGameWPF.GameHolder.Koma.MoveableRange
{
	public partial class MoveableRange
	{
		/// <summary>
		/// 帥可以移動的範圍
		/// </summary>
		/// <returns>可以移動範圍的三維陣列</returns>
		public static Point[][][] MoveableRange帥()
		{
			return new Point[][][]
			{
                // 上
                new Point[][]
				{
					new Point[] { new Point(0, -1) },
					new Point[] { new Point(0, -2) },
					new Point[] { new Point(0, -3) }
				},
                // 右上
                new Point[][]
				{
					new Point[] { new Point(1, -1) },
					new Point[] { new Point(2, -2) },
					new Point[] { new Point(3, -3) }
				},
                // 右
                new Point[][]
				{
					new Point[] { new Point(1, 0) },
					new Point[] { new Point(2, 0) },
					new Point[] { new Point(3, 0) }
				},
				// 右下
				new Point[][]
				{
					new Point[] { new Point(1, 1) },
					new Point[] { new Point(2, 2) },
					new Point[] { new Point(3, 3) }
				},
                // 下
                new Point[][]
				{
					new Point[] { new Point(0, 1) },
					new Point[] { new Point(0, 2) },
					new Point[] { new Point(0, 3) }
				},
                // 左下
                new Point[][]
				{
					new Point[] { new Point(-1, 1) },
					new Point[] { new Point(-2, 2) },
					new Point[] { new Point(-3, 3) }
				},
                // 左
                new Point[][]
				{
					new Point[] { new Point(-1, 0) },
					new Point[] { new Point(-2, 0) },
					new Point[] { new Point(-3, 0) }
				},
				// 左上
				new Point[][]
				{
					new Point[] { new Point(-1, -1) },
					new Point[] { new Point(-2, -2) },
					new Point[] { new Point(-3, -3) }
				}
			};
		}

		/// <summary>
		/// 大可以移動的範圍
		/// </summary>
		/// <returns>可以移動範圍的三維陣列</returns>
		public static Point[][][] MoveableRange大()
		{
			return new Point[][][]
			{
                // 上
                new Point[][]
				{
					new Point[]
					{
						new Point(0, -1), new Point(0, -2), new Point(0, -3),
						new Point(0, -4), new Point(0, -5), new Point(0, -6),
						new Point(0, -7), new Point(0, -8), new Point(0, -9),
					},
					Array.Empty<Point>(),
					Array.Empty<Point>(),
				},
                // 右上
                new Point[][]
				{
					new Point[] { new Point(1, -1) },
					new Point[] { new Point(2, -2) },
					new Point[] { new Point(3, -3) },
				},
                // 右
                new Point[][]
				{
					new Point[]
					{
						new Point(1, 0), new Point(2, 0), new Point(3, 0),
						new Point(4, 0), new Point(5, 0), new Point(6, 0),
						new Point(7, 0), new Point(8, 0), new Point(9, 0),
					},
					Array.Empty<Point>(),
					Array.Empty<Point>(),
				},
                // 右下
                new Point[][]
				{
					new Point[] { new Point(1, 1) },
					new Point[] { new Point(2, 2) },
					new Point[] { new Point(3, 3) },
				},
                // 下
                new Point[][]
				{
					new Point[]
					{
						new Point(0, 1), new Point(0, 2), new Point(0, 3),
						new Point(0, 4), new Point(0, 5), new Point(0, 6),
						new Point(0, 7), new Point(0, 8), new Point(0, 9)
					},
					Array.Empty<Point>(),
					Array.Empty<Point>(),
				},
                // 左下
                new Point[][]
				{
					new Point[] { new Point(-1, 1) },
					new Point[] { new Point(-2, 2) },
					new Point[] { new Point(-3, 3) },
				},
                // 左
                new Point[][]
				{
					new Point[]
					{
						new Point(-1, 0), new Point(-2, 0), new Point(-3, 0),
						new Point(-4, 0), new Point(-5, 0), new Point(-6, 0),
						new Point(-7, 0), new Point(-8, 0), new Point(-9, 0),
					},
					Array.Empty<Point>(),
					Array.Empty<Point>(),
				},
                // 左上
                new Point[][]
				{
					new Point[] { new Point(-1, -1) },
					new Point[] { new Point(-2, -2) },
					new Point[] { new Point(-3, -3) },
				}
			};
		}

		/// <summary>
		/// 中可以移動的範圍
		/// </summary>
		/// <returns>可以移動範圍的三維陣列</returns>
		public static Point[][][] MoveableRange中()
		{
			return new Point[][][]
			{
                // 上
                new Point[][]
				{
					new Point[] { new Point(0, -1) },
					new Point[] { new Point(0, -2) },
					new Point[] { new Point(0, -3) }
				},
                // 右上
                new Point[][]
				{
					new Point[]
					{
						new Point(1, -1), new Point(2, -2), new Point(3, -3),
						new Point(4, -4), new Point(5, -5), new Point(6, -6),
						new Point(7, -7), new Point(8, -8), new Point(9, -9)
					},
					Array.Empty<Point>(),
					Array.Empty<Point>()
				},
                // 右
                new Point[][]
				{
					new Point[] { new Point(1, 0) },
					new Point[] { new Point(2, 0) },
					new Point[] { new Point(3, 0) }
				},
                // 右下
                new Point[][]
				{
					new Point[]
					{
						new Point(1, 1), new Point(2, 2), new Point(3, 3),
						new Point(4, 4), new Point(5, 5), new Point(6, 6),
						new Point(7, 7), new Point(8, 8), new Point(9, 9)
					},
					Array.Empty<Point>(),
					Array.Empty<Point>()
				},
                // 下
                new Point[][]
				{
					new Point[] { new Point(0, 1) },
					new Point[] { new Point(0, 2) },
					new Point[] { new Point(0, 3) }
				},
                // 左下
                new Point[][]
				{
					new Point[]
					{
						new Point(-1, 1), new Point(-2, 2), new Point(-3, 3),
						new Point(-4, 4), new Point(-5, 5), new Point(-6, 6),
						new Point(-7, 7), new Point(-8, 8), new Point(-9, 9)
					},
					Array.Empty<Point>(),
					Array.Empty<Point>()
				},
                // 左
                new Point[][]
				{
					new Point[] { new Point(-1, 0) },
					new Point[] { new Point(-2, 0) },
					new Point[] { new Point(-3, 0) }
				},
                // 左上
                new Point[][]
				{
					new Point[]
					{
						new Point(-1, -1), new Point(-2, -2), new Point(-3, -3),
						new Point(-4, -4), new Point(-5, -5), new Point(-6, -6),
						new Point(-7, -7), new Point(-8, -8), new Point(-9, -9)
					},
					Array.Empty<Point>(),
					Array.Empty<Point>()
				}
			};
		}

		/// <summary>
		/// 小可以移動的範圍
		/// </summary>
		/// <returns>可以移動範圍的三維陣列</returns>
		public static Point[][][] MoveableRange小()
		{
			return new Point[][][]
			{
                // 上
                new Point[][]
				{
					new Point[] { new Point(0, -1) },
					new Point[] { new Point(0, -2) },
					new Point[] { new Point(0, -3) },
				},
				// 右上
				new Point[][]
				{
					new Point[] { new Point(1, -1) },
					new Point[] { new Point(2, -2) },
					new Point[] { new Point(3, -3) },
				},
				// 右
				new Point[][]
				{
					new Point[] { new Point(1, 0) },
					new Point[] { new Point(2, 0) },
					new Point[] { new Point(3, 0) }
				},
				// 右下
				Array.Empty<Point[]>(),
				// 下
				new Point[][]
				{
					new Point[] { new Point(0, 1) },
					new Point[] { new Point(0, 2) },
					new Point[] { new Point(0, 3) },
				},
				// 左下
				Array.Empty<Point[]>(),
				// 左
				new Point[][]
				{
					new Point[] { new Point(-1, 0) },
					new Point[] { new Point(-2, 0) },
					new Point[] { new Point(-3, 0) }
				},
				// 左上
				new Point[][]
				{
					new Point[] { new Point(-1, -1) },
					new Point[] { new Point(-2, -2) },
					new Point[] { new Point(-3, -3) },
				}
			};
		}

		/// <summary>
		/// 侍可以移動的範圍
		/// </summary>
		/// <returns>可以移動範圍的三維陣列</returns>
		public static Point[][][] MoveableRange侍()
		{
			return new Point[][][]
			{
                // 上
                new Point[][]
				{
					new Point[] { new Point(0, -1) },
					new Point[] { new Point(0, -2) },
					new Point[] { new Point(0, -3) }
				},
				// 右上
				new Point[][]
				{
					new Point[] { new Point(1, -1) },
					new Point[] { new Point(2, -2) },
					new Point[] { new Point(3, -3) }
				},
				// 右
				Array.Empty<Point[]>(),
				// 右下
				Array.Empty<Point[]>(),
				// 下
				new Point[][]
				{
					new Point[] { new Point(0, 1) },
					new Point[] { new Point(0, 2) },
					new Point[] { new Point(0, 3) }
				},
				// 左下
				Array.Empty<Point[]>(),
				// 左
				Array.Empty<Point[]>(),
				//左上
				new Point[][]
				{
					new Point[] { new Point(-1, -1) },
					new Point[] { new Point(-2, -2) },
					new Point[] { new Point(-3, -3) }
				}
			};
		}

		/// <summary>
		///	忍可以移動的範圍 
		/// </summary>
		/// <returns>可以移動範圍的三維陣列</returns>
		public static Point[][][] MoveableRange忍()
		{
			return new Point[][][]
			{
                // 上
                Array.Empty<Point[]>(),
				// 右上
				new Point[][]
				{
					new Point[]
					{
						new Point(1, -1), new Point(2, -2)
					},
					new Point[] { new Point(3, -3) },
					new Point[] { new Point(4, -4) }
				},
				// 右
				Array.Empty<Point[]>(),
				// 右下
				new Point[][]
				{
					new Point[]
					{
						new Point(1, 1), new Point(2, 2)
					},
					new Point[] { new Point(3, 3) },
					new Point[] { new Point(4, 4) }
				},
				// 下
				Array.Empty<Point[]>(),
				// 左下
				new Point[][]
				{
					new Point[]
					{
						new Point(-1, 1), new Point(-2, 2)
					},
					new Point[] { new Point(-3, 3) },
					new Point[] { new Point(-4, 4) }
				},
				// 左
				Array.Empty<Point[]>(),
				// 左上
				new Point[][]
				{
					new Point[]
					{
						new Point(-1, -1), new Point(-2, -2)
					},
					new Point[] { new Point(-3, -3) },
					new Point[] { new Point(-4, -4) }
				}
			};
		}

		/// <summary>
		///	槍可以移動的範圍 
		/// </summary>
		/// <returns>可以移動範圍的三維陣列</returns>
		public static Point[][][] MoveableRange槍()
		{
			return new Point[][][]
			{
                // 上
                new Point[][]
				{
					new Point[]
					{
						new Point(0, -1), new Point(0, -2)
					},
					new Point[] { new Point(0, -3) },
					new Point[] { new Point(0, -4) }
				},
				// 右上
				new Point[][]
				{
					new Point[] { new Point(1, -1) },
					new Point[] { new Point(2, -2) },
					new Point[] { new Point(3, -3) }
				},
				// 右
				Array.Empty<Point[]>(),
				// 右下
				Array.Empty<Point[]>(),
				// 下
				new Point[][]
				{
					new Point[] { new Point(0, 1) },
					new Point[] { new Point(0, 2) },
					new Point[] { new Point(0, 3) }
				},
				// 左下
				Array.Empty<Point[]>(),
				// 左
				Array.Empty<Point[]>(),
				// 左上
				new Point[][]
				{
					new Point[] { new Point(-1, -1) },
					new Point[] { new Point(-2, -2) },
					new Point[] { new Point(-3, -3) }
				}
			};
		}

		/// <summary>
		///	砦可以移動的範圍 
		/// </summary>
		/// <returns>可以移動範圍的三維陣列</returns>
		public static Point[][][] MoveableRange砦()
		{
			return new Point[][][]
			{
                // 上
                new Point[][]
				{
					new Point[] { new Point(0, -1) },
					new Point[] { new Point(0, -2) },
					new Point[] { new Point(0, -3) }
				},
				// 右上
				Array.Empty<Point[]>(),
				// 右
				new Point[][]
				{
					new Point[] { new Point(1, 0) },
					new Point[] { new Point(2, 0) },
					new Point[] { new Point(3, 0) }
				},
				// 右下
				new Point[][]
				{
					new Point[] { new Point(1, 1) },
					new Point[] { new Point(2, 2) },
					new Point[] { new Point(3, 3) }
				},
				// 下
				Array.Empty<Point[]>(),
				// 左下
				new Point[][]
				{
					new Point[] { new Point(-1, 1) },
					new Point[] { new Point(-2, 2) },
					new Point[] { new Point(-3, 3) }
				},
				// 左
				new Point[][]
				{
					new Point[] { new Point(-1, 0) },
					new Point[] { new Point(-2, 0) },
					new Point[] { new Point(-3, 0) }
				},
				// 左上
				Array.Empty<Point[]>()
			};
		}

		/// <summary>
		/// 馬可以移動的範圍
		/// </summary>
		/// <returns>可以移動範圍的三維陣列</returns>
		public static Point[][][] MoveableRange馬()
		{
			return new Point[][][]
			{
                // 上
                new Point[][]
				{
					new Point[]
					{
						new Point(0, -1), new Point(0, -2)
					},
					new Point[] { new Point(0, -3) },
					new Point[] { new Point(0, -4) }
				},
				// 右上
				Array.Empty<Point[]>(),
				// 右
				new Point[][]
				{
					new Point[] { new Point(1, 0) },
					new Point[] { new Point(2, 0) },
					new Point[] { new Point(3, 0) }
				},
				// 右下
				Array.Empty<Point[]>(),
				// 下
				new Point[][]
				{
					new Point[]
					{
						new Point(0, 1), new Point(0, 2)
					},
					new Point[] { new Point(0, 3) },
					new Point[] { new Point(0, 4) }
				},
				// 左下
				Array.Empty<Point[]>(),
				// 左
				new Point[][]
				{
					new Point[] { new Point(-1, 0) },
					new Point[] { new Point(-2, 0) },
					new Point[] { new Point(-3, 0) }
				},
				// 左上
				Array.Empty<Point[]>()
			};
		}

		/// <summary>
		/// 兵可以移動的範圍
		/// </summary>
		/// <returns>可以移動範圍的三維陣列</returns>
		public static Point[][][] MoveableRange兵()
		{
			return new Point[][][]
			{
                // 上
                new Point[][]
				{
					new Point[] { new Point(0, -1) },
					new Point[] { new Point(0, -2) },
					new Point[] { new Point(0, -3) }
				},
				// 右上
				Array.Empty<Point[]>(),
				// 右
				Array.Empty<Point[]>(),
				// 右下
				Array.Empty<Point[]>(),
				// 下
				new Point[][]
				{
					new Point[] { new Point(0, 1) },
					new Point[] { new Point(0, 2) },
					new Point[] { new Point(0, 3) }
				},
				// 左下
				Array.Empty<Point[]>(),
				// 左
				Array.Empty<Point[]>(),
				// 左上
				Array.Empty<Point[]>()
			};
		}

		/// <summary>
		/// 弓可以移動的範圍
		/// </summary>
		/// <returns>可以移動範圍的三維陣列</returns>
		public static Point[][][] MoveableRange弓()
		{
			return new Point[][][]
			{
                // 上
                new Point[][]
				{
					new Point[] { new Point(0, -2) },
					new Point[] { new Point(0, -3) },
					new Point[] { new Point(0, -4) }
				},
				// 右上
				new Point[][]
				{
					new Point[] { new Point(1, -2) },
					new Point[] { new Point(2, -3) },
					new Point[] { new Point(3, -4) }
				},
				// 右
				Array.Empty <Point[]>(),
				// 右下
				Array.Empty<Point[]>(),
				// 下
				new Point[][]
				{
					new Point[] { new Point(0, 1) },
					new Point[] { new Point(0, 2) },
					new Point[] { new Point(0, 3) }
				},
				// 左下
				Array.Empty<Point[]>(),
				// 左
				Array.Empty<Point[]>(),
				// 左上
				new Point[][]
				{
					new Point[] { new Point(-1, -2) },
					new Point[] { new Point(-2, -3) },
					new Point[] { new Point(-3, -4) }
				}
			};
		}

		/// <summary>
		/// 砲可以移動的範圍
		/// </summary>
		/// <returns>可以移動範圍的三維陣列</returns>
		public static Point[][][] MoveableRange砲()
		{
			return new Point[][][]
			{
                // 上
                new Point[][]
				{
					new Point[] { new Point(0, -3) },
					new Point[] { new Point(0, -4) },
					new Point[] { new Point(0, -5) }
				},
				// 右上
				Array.Empty<Point[]>(),
				// 右
				new Point[][]
				{
					new Point[] { new Point(1, 0) },
					new Point[] { new Point(2, 0) },
					new Point[] { new Point(3, 0) }
				},
				// 右下
				Array.Empty<Point[]>(),
				// 下
				new Point[][]
				{
					new Point[] { new Point(0, 1) },
					new Point[] { new Point(0, 2) },
					new Point[] { new Point(0, 3) }
				},
				// 左下
				Array.Empty<Point[]>(),
				// 左
				new Point[][]
				{
					new Point[] { new Point(-1, 0) },
					new Point[] { new Point(-2, 0) },
					new Point[] { new Point(-3, 0) }
				},
				// 左上
				Array.Empty<Point[]>()
			};
		}

		/// <summary>
		/// 筒可以移動的範圍
		/// </summary>
		/// <returns>可以移動範圍的三維陣列</returns>
		public static Point[][][] MoveableRange筒()
		{
			return new Point[][][]
			{
                // 上
                new Point[][]
				{
					new Point[] { new Point(0, -2) },
					new Point[] { new Point(0, -3) },
					new Point[] { new Point(0, -4) }
				},
				// 右上
				Array.Empty<Point[]>(),
				// 右
				Array.Empty<Point[]>(),
				// 右下
				new Point[][]
				{
					new Point[] { new Point(1, 1) },
					new Point[] { new Point(2, 2) },
					new Point[] { new Point(3, 3) }
				},
				// 下
				Array.Empty<Point[]>(),
				// 左下
				new Point[][]
				{
					new Point[] { new Point(-1, 1) },
					new Point[] { new Point(-2, 2) },
					new Point[] { new Point(-3, 3) }
				},
				// 左
				Array.Empty<Point[]>(),
				// 左上
				Array.Empty<Point[]>()
			};
		}

		/// <summary>
		/// 謀可以移動的範圍
		/// </summary>
		/// <returns>可以移動範圍的三維陣列</returns>
		public static Point[][][] MoveableRange謀()
		{
			return new Point[][][]
			{
                // 上
                Array.Empty<Point[]>(),
				// 右上
				new Point[][]
				{
					new Point[] { new Point(1, -1) },
					new Point[] { new Point(2, -2) },
					new Point[] { new Point(3, -3) }
				},
				// 右
				Array.Empty<Point[]>(),
				// 右下
				Array.Empty<Point[]>(),
				// 下
				new Point[][]
				{
					new Point[] { new Point(0, 1) },
					new Point[] { new Point(0, 2) },
					new Point[] { new Point(0, 3) }
				},
				// 左下
			Array.Empty<Point[]>(),
			// 左
			Array.Empty<Point[]>(),
			// 左上
			new Point[][]
			{
				new Point[] { new Point(-1, -1) },
				new Point[] { new Point(-2, -2) },
					new Point[] { new Point(-3, -3) }
				}
			};
		}
	}
}