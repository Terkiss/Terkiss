﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Data_Structor
{
    public class JeongBinaryTree<T>
    {
        private JeongBinaryTreeNode<T> Root = null;
        private int count = 0;
        private int length = 0;
        private int depth = 0;



        
        public void AddNode(T Data)
        {
            JeongStack<JeongBinaryTreeNode<T>> JJStack = new JeongStack<JeongBinaryTreeNode<T>>();

            JeongBinaryTreeNode<T> ParrentNode = null;
  
            try
            {
                SearchBinaryTree(ref ParrentNode, Data);
            }
            catch (Exception ex)
            {
                Console.WriteLine("이진 트리 range 에러");
            }

            if (ParrentNode != null)
            {// 설정한 임시 부모노드가 널이 아닐경우 삽입을 시작 에외처리에 주의 

                if (Comparerser(Data, ParrentNode.Data) == true)
                {
                    /// 입력 데이터가 부모 노드의 키보다 작을 경우 
                    JeongBinaryTreeNode<T> tempDataNode = new JeongBinaryTreeNode<T>();
                    tempDataNode.Data = Data;
                    ParrentNode.Left = tempDataNode;
                    count++;
                }
                else
                {
                    /// 입력 데잍터가 부모 노드의 키보다 클 경우 
                    JeongBinaryTreeNode<T> tempDataNode = new JeongBinaryTreeNode<T>();
                    tempDataNode.Data = Data;
                    ParrentNode.Right = tempDataNode;
                    count++;
                }

            }
            else
            {

                JeongBinaryTreeNode<T> TempData = new JeongBinaryTreeNode<T>();
                TempData.Data = Data;
                Root = TempData;

            }

        }

        public void TreeClean()
        {
            Root = null;
        }



        public void PreorderPrintTree()
        {

        }

        public void InorderPrintTree()
        {

        }

        public void postorderPrintTree()
        {

        }


        /// <summary>
        /// 이진 탐색 트리의 탐색 함수
        /// 좌측 값 vs 우측 값
        /// 비교를 통해 
        /// 작으면 왼쪽
        /// 크면 오른쪽으로 탐색
        /// </summary>
        /// <param name="ParrentNode"></param>
        /// <param name="Data"></param>
        private void SearchBinaryTree(ref JeongBinaryTreeNode<T> ParrentNode, T Data)
        {
            JeongBinaryTreeNode<T> Current = Root;
            while (Current != null)
            {
                if (ZeroComparerser(Data, Current.Data) == true)
                {
                    Console.WriteLine("동일한 데이터가 트리안에 있습니다. ");
                    return;
                }

                ParrentNode = Current; // 현재 탐색 중인 노드를 임시 부모 로 설정 


                if (Comparerser(Data, Current.Data) == true)
                {
                    Current = Current.Left;
                }
                else
                {
                    Current = Current.Right;
                }
            }
        }

        /// <summary>
        /// 비교 함수
        /// 오른 쪽 이 왼쪽 변수보다 크거나 같으면  TRUE를 반환
        ///                         왼쪽 변수가 오른쪽 변수 보다 작으면 FALSE 를 반환
        /// </summary>
        /// <param name="value"> 좌 </param>
        /// <param name="value2"> 우</param>
        /// <returns></returns>
        private bool Comparerser(T value, T value2)
        {
            var result = Comparer<T>.Default.Compare(value, value2);
            if (result < 0) { return true; }
            else { return false; }
        }

        private bool ZeroComparerser(T value, T value2)
        {
            var result = Comparer<T>.Default.Compare(value, value2);
            if (result == 0) { return true; }
            else { return false; }
        }
    }
}
