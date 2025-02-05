/*----------------------------------------------------------------
// Copyright © 2024 HYC. All Rights Reserved
// 版权所有。
//
// =================================
// CLR版本     ：4.0.30319.42000
// 命名空间    ：Music.Base
// 文件名称    ：Command
// =================================
// 创 建 者    ：DongFuxiang
// 创建日期    ：2024/4/21 18:47:03
// 功能描述    ：
// 使用说明    ：
//
//
// 创建标识：
//
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Music.Base
{
    public class Command<T> : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            dynamic param = parameter;

            DoExecute?.Invoke(param);

        }

        public Action<T> DoExecute { get; set; }
        public Command(Action<T> action)
        {
            DoExecute = action;
        }
    }

    public class Command : Command<object>
    {
        public Command(Action action) : base(obj => action?.Invoke()) { }
    }

}
