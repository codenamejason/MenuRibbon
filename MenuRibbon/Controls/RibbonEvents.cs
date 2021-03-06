﻿using MenuRibbon.WPF.Controls.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MenuRibbon.WPF.Controls
{
	/// <summary>
	///     Enumeration for horizontal placement of KeyTip
	///     with respect to its placement target.
	/// </summary>
	public enum KeyTipHorizontalPlacement
	{
		KeyTipLeftAtTargetLeft = 0,
		KeyTipLeftAtTargetCenter,
		KeyTipLeftAtTargetRight,
		KeyTipCenterAtTargetLeft,
		KeyTipCenterAtTargetCenter,
		KeyTipCenterAtTargetRight,
		KeyTipRightAtTargetLeft,
		KeyTipRightAtTargetCenter,
		KeyTipRightAtTargetRight
	}

	/// <summary>
	///     Enumeration for vertical placement of the KeyTip
	///     with respect to its placement target.
	/// </summary>
	public enum KeyTipVerticalPlacement
	{
		KeyTipTopAtTargetTop = 0,
		KeyTipTopAtTargetCenter,
		KeyTipTopAtTargetBottom,
		KeyTipCenterAtTargetTop,
		KeyTipCenterAtTargetCenter,
		KeyTipCenterAtTargetBottom,
		KeyTipBottomAtTargetTop,
		KeyTipBottomAtTargetCenter,
		KeyTipBottomAtTargetBottom
	}

	/// <summary>
	/// Event argument for <see cref="KeyTipService.ActivatingKeyTipEvent"/> 
	/// </summary>
	public class ActivatingKeyTipEventArgs : RoutedEventArgs
	{
		#region Constructor

		public ActivatingKeyTipEventArgs()
		{
			RoutedEvent = KeyTipService.ActivatingKeyTipEvent;

			KeyTipHorizontalPlacement = KeyTipHorizontalPlacement.KeyTipCenterAtTargetCenter;
			KeyTipVerticalPlacement = KeyTipVerticalPlacement.KeyTipBottomAtTargetBottom;
			PlacementTarget = null;
			KeyTipHorizontalOffset = 0;
			KeyTipVerticalOffset = 0;
			KeyTipVisibility = Visibility.Visible;
		}

		#endregion

		#region Properties

		/// <summary>
		///     Horizontal placement for KeyTip
		/// </summary>
		public KeyTipHorizontalPlacement KeyTipHorizontalPlacement { get; set; }

		/// <summary>
		///     Vertical placement for KeyTip
		/// </summary>
		public KeyTipVerticalPlacement KeyTipVerticalPlacement { get; set; }

		/// <summary>
		///     Placement target for KeyTip
		/// </summary>
		public UIElement PlacementTarget { get; set; }

		/// <summary>
		///     Horizontal offset from the defined horizontal placement.
		/// </summary>
		public double KeyTipHorizontalOffset
		{
			get
			{
				return _horizontalOffset;
			}
			set
			{
				if (double.IsInfinity(value) || double.IsNaN(value))
				{
					throw new ArgumentException();
				}
				_horizontalOffset = value;
			}
		}
		private double _horizontalOffset = 0;

		/// <summary>
		///     Vertical offset from the defined vertical placement.
		/// </summary>
		public double KeyTipVerticalOffset
		{
			get
			{
				return _verticalOffset;
			}
			set
			{
				if (double.IsInfinity(value) || double.IsNaN(value))
				{
					throw new ArgumentException();
				}
				_verticalOffset = value;
			}
		}
		private double _verticalOffset = 0;

		/// <summary>
		///     Visibility for the KeyTip.
		///     Visible: KeyTip will be visible (if it can) and functional / accessible.
		///     Hidden: KeyTip will be hidden but will be accessible.
		///     Collapsed: KeyTip will not be visible and will not be accessible.
		/// </summary>
		public Visibility KeyTipVisibility { get; set; }

		/// <summary>
		///     Used for nudging vertical position to RibbonGroup's top/bottom axis
		/// </summary>
		internal RibbonGroup OwnerRibbonGroup { get; set; }

		#endregion

		#region Protected Methods

		protected override void InvokeEventHandler(Delegate genericHandler, object genericTarget)
		{
			ActivatingKeyTipEventHandler handler = (ActivatingKeyTipEventHandler)genericHandler;
			handler(genericTarget, this);
		}

		#endregion
	}

	/// <summary>
	///     Event handler type for <see cref="KeyTipService.ActivatingKeyTipEvent"/> 
	/// </summary>
	public delegate void ActivatingKeyTipEventHandler(object sender, ActivatingKeyTipEventArgs e);

	/// <summary>
	///     Event argument for <see cref="KeyTipService.KeyTipAccessedEvent"/> 
	/// </summary>
	public class KeyTipAccessedEventArgs : RoutedEventArgs
	{
		public KeyTipAccessedEventArgs()
		{
		}

		/// <summary>
		///     This property determines what will be the
		///     next KeyTip scope after routing this event.
		/// </summary>
		public DependencyObject TargetKeyTipScope { get; set; }

		protected override void InvokeEventHandler(Delegate genericHandler, object genericTarget)
		{
			KeyTipAccessedEventHandler handler = (KeyTipAccessedEventHandler)genericHandler;
			handler(genericTarget, this);
		}
	}

	/// <summary>
	///     Event handler type for <see cref="KeyTipService.KeyTipAccessedEvent"/>.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	public delegate void KeyTipAccessedEventHandler(object sender, KeyTipAccessedEventArgs e);
}
