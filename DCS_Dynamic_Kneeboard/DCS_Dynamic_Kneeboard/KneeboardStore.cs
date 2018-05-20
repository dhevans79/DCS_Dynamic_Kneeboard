using System;
using System.Collections.Generic;
using System.Text;
using PCLStorage;

namespace DCS_Dynamic_Kneeboard
{
    class KneeboardStore
    {
        private static KneeboardStore instance = new KneeboardStore();
        private Dictionary<string, Kneeboard> kneeboards = new Dictionary<string, Kneeboard>();

        private KneeboardStore() { }

        public static KneeboardStore Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KneeboardStore();
                }
                return instance;
            }

        }

        public async void LoadKneeboards()
        {
            char[] lineSeparator = Environment.NewLine.ToCharArray();
            char[] valueSeparator = "¦~¦".ToCharArray();

            int kbIdx, kbIdxIdx, kbTitleIdx, kbDescIdx, kbPagesIdx;
            kbIdx = 0;
            kbIdxIdx = 1;
            kbTitleIdx = 2;
            kbDescIdx = 3;
            kbPagesIdx = 4;
            // kb              ¦~¦ idx ¦~¦ title              ¦~¦ desc                          ¦~¦ Dict<>
            // MiG21FF         ¦~¦  1  ¦~¦ MiG 21 Freeflight  ¦~¦ Kneeboard for freeflight      ¦~¦ MigStrt,MigTO,MigAAR,MigLand,MigShtDwn
            // MiG21MissOpChck ¦~¦  2  ¦~¦ MiG 21 Op Shutdown ¦~¦ Kneeboard for Mission Shtdown ¦~¦ MigStrt,OpShtMAP,MigAAR,MigLand

            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("KneeboardStore", CreationCollisionOption.OpenIfExists);
            IFile file = await folder.GetFileAsync("Kneeboards.obj");
            string fileData = await file.ReadAllTextAsync();

            string[] kneeboardData = fileData.Split(lineSeparator);

            foreach (string kneeboardItem in kneeboardData)
            {
                string[] listArr = kneeboardItem.Split(valueSeparator);
                string pageName = listArr[kbIdx];
                int kneeboardIdx = Convert.ToInt32(listArr[kbIdxIdx]);

                Kneeboard kneeboard = new Kneeboard
                {
                    Title = listArr[kbTitleIdx],
                    Description = listArr[kbDescIdx]
                };

                Dictionary<string, Page> tmpPageList = new Dictionary<string, Page>();

                foreach (string pageidx in listArr[kbPagesIdx].Split(','))
                {
                    Page tmpPage = PagesStore.Instance.GetPage(pageidx);
                    if (tmpPage != null)
                        tmpPageList.Add(((Page)tmpPage).PageName, tmpPage);
                }

                kneeboard.Pages = tmpPageList;
                kneeboards.Add(kneeboard.Title, kneeboard);
            }
        }
    }
}