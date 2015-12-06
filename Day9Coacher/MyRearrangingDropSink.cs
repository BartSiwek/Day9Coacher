using System;
using System.Collections.Generic;
using System.Text;
using BrightIdeasSoftware;
using System.Windows.Forms;

namespace Day9Coacher
{
    public class MyRearrangingDropSink : RearrangingDropSink
    {
        //Events
        public event EventHandler<EventArgs> AfterDropped;

        //Constructors
        public MyRearrangingDropSink() 
            : base() {
        }

        public MyRearrangingDropSink(bool acceptDropsFromOtherLists)
            : base(acceptDropsFromOtherLists) {
        }

        //Methods
        protected override void TriggerDroppedEvent(DragEventArgs args)
        {
            base.TriggerDroppedEvent(args);
            this.OnAfterDropped(EventArgs.Empty);
        }

        protected virtual void OnAfterDropped(EventArgs args)
        {
            if (this.AfterDropped != null)
                this.AfterDropped(this, args);
        }
    }
}
