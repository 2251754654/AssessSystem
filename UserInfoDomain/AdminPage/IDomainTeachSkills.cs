using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Domains
{
    public interface IDomainTeachSkills
    {
        /// <summary>
        /// 查询专业技能
        /// </summary>
        /// <returns></returns>
         List<ModelTechSkills> FindAllTeachSkills();
        /// <summary>
        /// 更专业心技能
        /// </summary>
        /// <returns></returns>
         bool UpdateTeackSkills(ModelTechSkills modelTechSkills);
        /// <summary>
        /// 删除专业技能
        /// </summary>
        /// <returns></returns>
        bool DeleteTeachSkills(int teackSkillsID);
        /// <summary>
        /// 插入专业技能
        /// </summary>
        /// <returns></returns>
        bool InsertTeachSkills(ModelTechSkills modelTechSkills);
        bool DeleteLever(int teachSkillsID, int teachLeverID);
        bool InsertLever(ModelTeachLever modelTeachLever);
        List<ModelTeachLever> FindAllLever(int teachSkillsID);
        List<ModelTechSkills> AllotTeachSkills(int professionalID);
    }
}
