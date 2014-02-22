using SmartQuant.Charting;
using SmartQuant.Execution;
using SmartQuant.FIX;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
namespace OpenQuant.API
{
	internal class OrderMarker : IDrawable, IZoomable
	{
		protected SingleOrder order;
		protected bool toolTipEnabled = true;
		protected string toolTipFormat = "{0} {1} {2} {3} @ {4} {5} {6}";
		private bool drawArrow = true;
		private Color limitColor = Color.Green;
		private Color stopColor = Color.Brown;
		private Color limitCancelColor = Color.Gray;
		private Color stopCancelColor = Color.Gray;
		private Color buyColor = Color.Blue;
		private Color sellColor = Color.Red;
		private Color sellShortColor = Color.Yellow;
		public SingleOrder Order
		{
			get
			{
				return this.order;
			}
		}
		public bool DrawArrow
		{
			get
			{
				return this.drawArrow;
			}
			set
			{
				this.drawArrow = value;
			}
		}
		public string ToolTipFormat
		{
			get
			{
				return this.toolTipFormat;
			}
			set
			{
				this.toolTipFormat = value;
			}
		}
		public bool ToolTipEnabled
		{
			get
			{
				return this.toolTipEnabled;
			}
			set
			{
				this.toolTipEnabled = value;
			}
		}
		public OrderMarker(SingleOrder order)
		{
			this.order = order;
		}
		public void Paint(Pad pad, double MinX, double MaxX, double MinY, double MaxY)
		{
			if (this.order.OrdType == OrdType.TrailingStop || this.order.OrdType == OrdType.TrailingStopLimit)
			{
				return;
			}
			DateTime now = Clock.Now;
			Color color = Color.Green;
			Pen pen;
			if (this.order.OrdStatus != OrdStatus.Cancelled && this.order.OrdStatus != OrdStatus.Rejected)
			{
				pen = new Pen(this.limitColor, 2f);
			}
			else
			{
				pen = new Pen(this.limitCancelColor, 2f);
			}
			pen.DashStyle = DashStyle.Dash;
			Pen pen2;
			if (this.order.OrdStatus != OrdStatus.Cancelled && this.order.OrdStatus != OrdStatus.Rejected)
			{
				pen2 = new Pen(this.stopColor, 2f);
			}
			else
			{
				pen2 = new Pen(this.stopCancelColor, 2f);
			}
			pen2.DashStyle = DashStyle.Dash;
			switch (this.order.OrdStatus)
			{
			case OrdStatus.Filled:
				color = Color.Green;
				break;
			case OrdStatus.Cancelled:
			case OrdStatus.Rejected:
				color = Color.Gray;
				break;
			case OrdStatus.Stopped:
				color = Color.Red;
				break;
			}
			DateTime transactTime = new DateTime(1, 1, 1);
			DateTime dateTime = new DateTime(1, 1, 1);
			DateTime transactTime2 = new DateTime(1, 1, 1);
			DateTime dateTime2 = new DateTime(1, 1, 1);
			float num = 12f;
			DateTime dateTime3 = DateTime.MaxValue;
			if (this.order.OrdStatus == OrdStatus.Cancelled || this.order.OrdStatus == OrdStatus.Rejected || this.order.OrdStatus == OrdStatus.PendingNew || this.order.OrdStatus == OrdStatus.Filled)
			{
				dateTime3 = this.order.Reports[this.order.Reports.Count - 1].TransactTime;
			}
			if (this.order.OrdType == OrdType.Stop || this.order.OrdType == OrdType.StopLimit)
			{
				transactTime = this.order.Reports[0].TransactTime;
				if (this.order.OrdStatus == OrdStatus.PendingNew)
				{
					dateTime = new DateTime(Math.Min(now.Ticks, (long)MaxX));
				}
				else
				{
					dateTime = new DateTime(Math.Min(now.Ticks, dateTime3.Ticks));
				}
				if ((double)transactTime.Ticks > MaxX || (double)dateTime.Ticks <= MinX)
				{
					return;
				}
				float num2 = (float)pad.ClientY(this.order.StopPx);
				float x = (float)pad.ClientX((double)transactTime.Ticks);
				float num3 = (float)pad.ClientX((double)dateTime.Ticks);
				pad.Graphics.DrawLine(pen2, x, num2, num3, num2);
				string priceDisplay = this.order.Instrument.PriceDisplay;
				string text;
				if (this.order.OrdStatus == OrdStatus.Filled)
				{
					text = this.order.Side.ToString() + " Stop at " + this.order.StopPx.ToString(priceDisplay) + " (Executed)";
				}
				else
				{
					if (this.order.OrdStatus == OrdStatus.Cancelled)
					{
						text = this.order.Side.ToString() + " Stop at " + this.order.StopPx.ToString(priceDisplay) + " (Canceled)";
					}
					else
					{
						if (this.order.OrdStatus == OrdStatus.Rejected)
						{
							text = this.order.Side.ToString() + " Stop at " + this.order.StopPx.ToString(priceDisplay) + " (Rejected)";
						}
						else
						{
							text = this.order.Side.ToString() + " Stop at " + this.order.StopPx.ToString(priceDisplay) + " (Pending)";
						}
					}
				}
				Font font = new Font("Arial", 8f);
				double num4;
				if (this.order.Side == Side.Buy)
				{
					num4 = (double)(num2 - 2f - (float)((int)pad.Graphics.MeasureString(text, font).Height));
				}
				else
				{
					num4 = (double)(num2 + 2f);
				}
				double num5 = (double)(num3 - (float)((int)pad.Graphics.MeasureString(text, font).Width) - 2f);
				pad.Graphics.DrawString(text, font, Brushes.Black, (float)num5, (float)num4);
			}
			if (this.order.OrdType == OrdType.Limit || this.order.OrdType == OrdType.StopLimit)
			{
				transactTime2 = this.order.Reports[0].TransactTime;
				if (this.order.OrdStatus == OrdStatus.New)
				{
					dateTime2 = new DateTime(Math.Min(now.Ticks, (long)MaxX));
				}
				else
				{
					dateTime2 = new DateTime(Math.Min(now.Ticks, dateTime3.Ticks));
				}
				if ((double)transactTime2.Ticks > MaxX || (double)dateTime2.Ticks <= MinX)
				{
					return;
				}
				float num6 = (float)pad.ClientY(this.order.Price);
				float x2 = (float)pad.ClientX((double)transactTime2.Ticks);
				float num7 = (float)pad.ClientX((double)dateTime2.Ticks);
				pad.Graphics.DrawLine(pen, x2, num6, num7, num6);
				string priceDisplay2 = this.order.Instrument.PriceDisplay;
				string text2;
				if (this.order.OrdStatus == OrdStatus.Filled)
				{
					text2 = this.order.Side.ToString() + " Limit at " + this.order.Price.ToString(priceDisplay2) + " (Executed)";
				}
				else
				{
					if (this.order.OrdStatus == OrdStatus.Cancelled)
					{
						text2 = this.order.Side.ToString() + " Limit at " + this.order.Price.ToString(priceDisplay2) + " (Canceled)";
					}
					else
					{
						if (this.order.OrdStatus == OrdStatus.Rejected)
						{
							text2 = this.order.Side.ToString() + " Limit at " + this.order.Price.ToString(priceDisplay2) + " (Rejected)";
						}
						else
						{
							bool flag = false;
							if (this.order.OrdType == OrdType.StopLimit)
							{
								for (int i = 0; i < this.order.Reports.Count; i++)
								{
									if (this.order.Reports[i].OrdStatus == OrdStatus.PendingNew)
									{
										flag = true;
										break;
									}
								}
							}
							if (flag || this.order.OrdType == OrdType.Limit)
							{
								text2 = this.order.Side.ToString() + " Limit at " + this.order.Price.ToString(priceDisplay2) + " (Pending)";
							}
							else
							{
								text2 = this.order.Side.ToString() + " Limit at " + this.order.Price.ToString(priceDisplay2) + " (New)";
							}
						}
					}
				}
				Font font2 = new Font("Arial", 8f);
				double num8;
				if (this.order.Side != Side.Buy)
				{
					num8 = (double)(num6 - 2f - (float)((int)pad.Graphics.MeasureString(text2, font2).Height));
				}
				else
				{
					num8 = (double)(num6 + 2f);
				}
				double num9 = (double)(num7 - (float)((int)pad.Graphics.MeasureString(text2, font2).Width) - 2f);
				pad.Graphics.DrawString(text2, font2, Brushes.Black, (float)num9, (float)num8);
			}
			if (this.order.OrdStatus == OrdStatus.Filled)
			{
				double avgPx = this.order.AvgPx;
				int num10 = pad.ClientY(avgPx);
				int num11 = pad.ClientX((double)dateTime3.Ticks);
				if (this.drawArrow)
				{
					switch (this.order.Side)
					{
					case Side.Buy:
					{
						color = this.buyColor;
						Point point = new Point(num11, num10);
						Point point2 = new Point((int)((float)num11 - num / 2f), (int)((float)num10 + num / 2f));
						Point point3 = new Point((int)((float)num11 + num / 2f), (int)((float)num10 + num / 2f));
						Point point4 = new Point((int)((float)num11 - num / 4f), (int)((float)num10 + num / 2f));
						Point point5 = new Point((int)((float)num11 + num / 4f), (int)((float)num10 + num / 2f));
						Point point6 = new Point((int)((float)num11 - num / 4f), (int)((float)num10 + num));
						Point point7 = new Point((int)((float)num11 + num / 4f), (int)((float)num10 + num));
						pad.Graphics.DrawPolygon(new Pen(color), new Point[]
						{
							point,
							point3,
							point5,
							point7,
							point6,
							point4,
							point2
						});
						return;
					}
					case Side.Sell:
					{
						color = this.sellColor;
						Point point = new Point(num11, num10);
						Point point2 = new Point((int)((float)num11 - num / 2f), (int)((float)num10 - num / 2f));
						Point point3 = new Point((int)((float)num11 + num / 2f), (int)((float)num10 - num / 2f));
						Point point4 = new Point((int)((float)num11 - num / 4f), (int)((float)num10 - num / 2f));
						Point point5 = new Point((int)((float)num11 + num / 4f), (int)((float)num10 - num / 2f));
						Point point6 = new Point((int)((float)num11 - num / 4f), (int)((float)num10 - num));
						Point point7 = new Point((int)((float)num11 + num / 4f), (int)((float)num10 - num));
						pad.Graphics.DrawPolygon(new Pen(color), new Point[]
						{
							point,
							point3,
							point5,
							point7,
							point6,
							point4,
							point2
						});
						return;
					}
					case Side.BuyMinus:
					case Side.SellPlus:
						break;
					case Side.SellShort:
					{
						color = this.sellShortColor;
						Point point = new Point(num11, num10);
						Point point2 = new Point((int)((float)num11 - num / 2f), (int)((float)num10 - num / 2f));
						Point point3 = new Point((int)((float)num11 + num / 2f), (int)((float)num10 - num / 2f));
						Point point4 = new Point((int)((float)num11 - num / 4f), (int)((float)num10 - num / 2f));
						Point point5 = new Point((int)((float)num11 + num / 4f), (int)((float)num10 - num / 2f));
						Point point6 = new Point((int)((float)num11 - num / 4f), (int)((float)num10 - num));
						Point point7 = new Point((int)((float)num11 + num / 4f), (int)((float)num10 - num));
						pad.Graphics.DrawPolygon(new Pen(color), new Point[]
						{
							point,
							point3,
							point5,
							point7,
							point6,
							point4,
							point2
						});
						break;
					}
					default:
						return;
					}
				}
			}
		}
		public TDistance Distance(double X, double Y)
		{
			DateTime now = Clock.Now;
			TDistance tDistance = new TDistance();
			double num = Math.Abs(this.order.Price);
			tDistance.X = X;
			tDistance.Y = num;
			FIXExecutionReport fIXExecutionReport = null;
			if (this.order.Reports.Count != 0)
			{
				fIXExecutionReport = this.order.Reports[this.order.Reports.Count - 1];
			}
			if (fIXExecutionReport == null)
			{
				return null;
			}
			if (this.order.OrdType == OrdType.Market && this.order.OrdStatus != OrdStatus.Filled)
			{
				return null;
			}
			StringBuilder stringBuilder = null;
			if (this.order.OrdType == OrdType.Market)
			{
				tDistance.X = (double)fIXExecutionReport.TransactTime.Ticks;
				tDistance.Y = fIXExecutionReport.Price;
				tDistance.dX = Math.Abs(X - tDistance.X);
				tDistance.dY = Math.Abs(Y - tDistance.Y);
				stringBuilder = new StringBuilder();
				if (fIXExecutionReport.TransactTime.Second != 0 || fIXExecutionReport.TransactTime.Minute != 0 || fIXExecutionReport.TransactTime.Hour != 0)
				{
					stringBuilder.AppendFormat(this.toolTipFormat, new object[]
					{
						this.order.OrdStatus.ToString(),
						this.order.Side.ToString(),
						this.order.Instrument.Symbol,
						this.order.OrderQty,
						"Market ",
						this.order.AvgPx,
						fIXExecutionReport.TransactTime
					});
				}
				else
				{
					stringBuilder.AppendFormat(this.toolTipFormat, new object[]
					{
						this.order.OrdStatus.ToString(),
						this.order.Side.ToString(),
						this.order.Instrument.Symbol,
						this.order.OrderQty,
						"Market ",
						this.order.AvgPx,
						fIXExecutionReport.TransactTime.ToShortDateString()
					});
				}
			}
			if (this.order.OrdType == OrdType.Stop || this.order.OrdType == OrdType.StopLimit)
			{
				num = Math.Abs(this.order.StopPx);
				tDistance.X = X;
				tDistance.Y = num;
				DateTime transactTime = this.order.Reports[0].TransactTime;
				if (X >= (double)transactTime.Ticks && ((this.order.OrdStatus != OrdStatus.Filled && this.order.OrdStatus != OrdStatus.Cancelled && this.order.OrdStatus != OrdStatus.Rejected && X <= (double)now.Ticks) || X <= (double)fIXExecutionReport.TransactTime.Ticks))
				{
					tDistance.dX = 0.0;
				}
				else
				{
					tDistance.dX = 1.7976931348623157E+308;
				}
				tDistance.dY = Math.Abs(Y - tDistance.Y);
				stringBuilder = new StringBuilder();
				if (transactTime.Second != 0 || transactTime.Minute != 0 || transactTime.Hour != 0)
				{
					stringBuilder.AppendFormat(this.toolTipFormat, new object[]
					{
						this.order.OrdStatus.ToString(),
						this.order.Side.ToString(),
						this.order.Instrument.Symbol,
						this.order.OrderQty,
						"Stop At ",
						num,
						fIXExecutionReport.TransactTime
					});
				}
				else
				{
					stringBuilder.AppendFormat(this.toolTipFormat, new object[]
					{
						this.order.OrdStatus.ToString(),
						this.order.Side.ToString(),
						this.order.Instrument.Symbol,
						this.order.OrderQty,
						"Stop At ",
						num,
						fIXExecutionReport.TransactTime.ToShortDateString()
					});
				}
			}
			if (this.order.OrdType == OrdType.Limit || this.order.OrdType == OrdType.StopLimit)
			{
				num = Math.Abs(this.order.Price);
				tDistance.X = X;
				tDistance.Y = num;
				DateTime transactTime2 = this.order.Reports[0].TransactTime;
				if (X >= (double)transactTime2.Ticks && ((this.order.OrdStatus != OrdStatus.Filled && this.order.OrdStatus != OrdStatus.Cancelled && this.order.OrdStatus != OrdStatus.Rejected && X <= (double)now.Ticks) || X <= (double)fIXExecutionReport.TransactTime.Ticks))
				{
					tDistance.dX = 0.0;
				}
				else
				{
					tDistance.dX = 1.7976931348623157E+308;
				}
				if (tDistance.dY > Math.Abs(Y - tDistance.Y))
				{
					tDistance.dY = Math.Abs(Y - tDistance.Y);
					stringBuilder = new StringBuilder();
					if (transactTime2.Second != 0 || transactTime2.Minute != 0 || transactTime2.Hour != 0)
					{
						stringBuilder.AppendFormat(this.toolTipFormat, new object[]
						{
							this.order.OrdStatus.ToString(),
							this.order.Side.ToString(),
							this.order.Instrument.Symbol,
							this.order.OrderQty,
							"Limit At ",
							num,
							fIXExecutionReport.TransactTime
						});
					}
					else
					{
						stringBuilder.AppendFormat(this.toolTipFormat, new object[]
						{
							this.order.OrdStatus.ToString(),
							this.order.Side.ToString(),
							this.order.Instrument.Symbol,
							this.order.OrderQty,
							"Limit At ",
							num,
							fIXExecutionReport.TransactTime.ToShortDateString()
						});
					}
				}
			}
			if (stringBuilder != null)
			{
				tDistance.ToolTipText = stringBuilder.ToString();
			}
			return tDistance;
		}
		public void Draw()
		{
			SmartQuant.Charting.Chart.Pad.Add(this);
		}
		public bool IsPadRangeY()
		{
			return this.order.OrdType != OrdType.TrailingStop && this.order.OrdType != OrdType.TrailingStopLimit;
		}
		public PadRange GetPadRangeY(Pad pad)
		{
			DateTime now = Clock.Now;
			FIXExecutionReport fIXExecutionReport = null;
			if (this.order.Reports.Count != 0)
			{
				fIXExecutionReport = this.order.Reports[this.order.Reports.Count - 1];
			}
			if (fIXExecutionReport == null)
			{
				return new PadRange(0.0, 0.0);
			}
			if (this.order.OrdType == OrdType.Market && this.order.OrdStatus != OrdStatus.Filled)
			{
				return new PadRange(0.0, 0.0);
			}
			FIXExecutionReport fIXExecutionReport2 = this.order.Reports[0];
			DateTime t = new DateTime((long)pad.XMin);
			DateTime t2 = new DateTime((long)pad.XMax);
			DateTime transactTime = fIXExecutionReport2.TransactTime;
			DateTime t3;
			if (this.order.OrdStatus == OrdStatus.Filled || this.order.OrdStatus == OrdStatus.Cancelled || this.order.OrdStatus == OrdStatus.Rejected)
			{
				t3 = fIXExecutionReport.TransactTime;
			}
			else
			{
				t3 = now;
			}
			if (!(t <= t3) || !(t2 >= transactTime) || this.order.OrdStatus == OrdStatus.Cancelled || this.order.OrdStatus == OrdStatus.Rejected)
			{
				return new PadRange(0.0, 0.0);
			}
			double val = this.order.AvgPx - 1E-10;
			double val2 = this.order.AvgPx + 1E-10;
			if (this.order.OrdType == OrdType.Limit)
			{
				int clientY = pad.ClientY(this.order.Price);
				if (this.order.Side == Side.Buy)
				{
					val2 = pad.WorldY(clientY);
					val = this.order.Price;
				}
				else
				{
					val = pad.WorldY(clientY);
					val2 = this.order.Price;
				}
			}
			if (this.order.OrdType == OrdType.Stop)
			{
				int clientY2 = pad.ClientY(this.order.StopPx);
				if (this.order.Side != Side.Buy)
				{
					val2 = pad.WorldY(clientY2);
					val = this.order.StopPx;
				}
				else
				{
					val = pad.WorldY(clientY2);
					val2 = this.order.StopPx;
				}
			}
			if (this.order.OrdType == OrdType.StopLimit)
			{
				int clientY3 = pad.ClientY(this.order.Price);
				int clientY4 = pad.ClientY(this.order.StopPx);
				if (this.order.Side == Side.Buy)
				{
					val2 = pad.WorldY(clientY3);
					val = pad.WorldY(clientY4);
				}
				else
				{
					val = pad.WorldY(clientY3);
					val2 = pad.WorldY(clientY4);
				}
			}
			return new PadRange(Math.Min(val, val2), Math.Max(val, val2));
		}
		public bool IsPadRangeX()
		{
			return false;
		}
		public PadRange GetPadRangeX(Pad pad)
		{
			return null;
		}
	}
}
