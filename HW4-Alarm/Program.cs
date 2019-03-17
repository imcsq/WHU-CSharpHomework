using System;

namespace HW4_Alarm
{
    // 闹钟事件委托类型
    public delegate void AlarmEventHandler(Alarm sender, AlarmEventArgs e);

    // 闹钟事件信息：记录当前第几次事件,表示一下事件信息参数的意思
    public class AlarmEventArgs: EventArgs
    {
        private int cnt;

        public AlarmEventArgs(int cnt)
        {
            this.cnt = cnt;
        }

        // 次数信息
        public int Count
        {
            get
            {
                return this.cnt;
            }
        }

    }

    // 闹钟类
    public class Alarm
    {
        public event AlarmEventHandler handler; //闹钟事件委托
        private int eventCnt; //闹钟事件计数器

        private DateTime targetTime;

        public Alarm(DateTime targetTime)
        {
            eventCnt = 0;
            this.targetTime = targetTime;
        }

        // 只读属性：闹钟目标时间
        public DateTime TargetTime
        {
            get => this.targetTime;
        }

        // 闹钟使能控制（每隔若干秒执行一次事件）
        public void enable(int intervalsec = 1)
        {
            while (DateTime.Now <= targetTime)
            {
                if (handler != null)
                    handler(this, new AlarmEventArgs(++this.eventCnt));
                System.Threading.Thread.Sleep(intervalsec * 1000);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Alarm myalarm;
            DateTime targetTime;

            // 输入目标时间，初始化闹钟实例
            do
            {
                Console.WriteLine("请输入闹钟响的目标时间");
                DateTime.TryParse(Console.ReadLine(), out targetTime);
            }
            while (targetTime == null);
            Console.WriteLine("闹钟时间为：" + targetTime);
            myalarm = new Alarm(targetTime);

            // 按需注册闹钟事件
            myalarm.handler += duang;
            myalarm.handler += printRemainBySeconds;
            //myalarm.handler += printRemainByDays;

            // 闹钟开始计时
            myalarm.enable();
        }

        // 打印秒数倒计时
        static void printRemainBySeconds(Alarm sender, AlarmEventArgs e)
        {
            Console.WriteLine("这是闹钟的第" + e.Count + "个事件");
            Console.WriteLine("事件类型：以秒为单位输出剩余时长");

            TimeSpan t = sender.TargetTime - DateTime.Now;
            Console.WriteLine("当前距离目标时间还剩余" + t.TotalSeconds + "秒");
        }

        // 打印分钟数倒计时
        static void printRemainByDays(Alarm sender, AlarmEventArgs e)
        {
            Console.WriteLine("这是闹钟的第" + e.Count + "个事件");
            Console.WriteLine("事件类型：以天为单位输出剩余时长");

            TimeSpan t = sender.TargetTime - DateTime.Now;
            Console.WriteLine("当前距离目标时间还剩余" + t.TotalDays + "天");
        }

        // 计时
        static void duang(Alarm sender, AlarmEventArgs e)
        {
            Console.WriteLine("这是闹钟的第" + e.Count + "个事件");
            Console.WriteLine("事件类型：准备报时");

            if (sender.TargetTime <= DateTime.Now)
                Console.WriteLine("!!!!!! 时间到啦 !!!!!!");
        }
    }
}
