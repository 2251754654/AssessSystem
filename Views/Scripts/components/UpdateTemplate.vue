   <!-- 更新模态框（Modal） -->
<template>
    <div class="modal fade" id="updateRole" tabindex="-1" role="dialog" aria-labelledby="updateRoleHead" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;
                    </button>
                    <h4 class="modal-title" id="updateRoleHead">
                        {{title}}
                    </h4>
                </div>
                <div class="modal-body">
                    <ul class="list-group form-group">
                        <li class="list-group-item">
                            <label class="text-info" for="RoleID">RoleID</label>
                            <input type="text" placeholder="RoleID" class="form-control" id="RoleID" v-model="roleObj.RoleID" disabled />
                        </li>
                        <li class="list-group-item">
                            <label class="text-info" for="RoleName">RoleName</label>
                            <input type="text" placeholder="RoleName" class="form-control" id="RoleName" v-model="roleObj.RoleName" />
                        </li>
                        <li class="list-group-item">
                            <label class="text-info" for="RoleDetails">RoleDetails</label>
                            <input type="text" placeholder="RoleDetails" class="form-control" id="RoleDetails" v-model="roleObj.RoleDetails" />
                        </li>
                    </ul>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-block btn-info" v-on:click="updateRole">提交</button>
                    <button type="button" data-dismiss="modal" class="btn btn-block btn-danger">退出</button>
                </div>
            </div><!-- /.modal-content -->
        </div><!-- /.modal -->
    </div>

</template>
<script>
    export default {
        data(){
            return {
                title:'标题'
            }
        },
        components: {

        }
    }
</script>