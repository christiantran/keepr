<template>
    <div class="container ">
    <!-- <div> -->

<!-- KEEP CARD -->
            <!-- <div v-for="k in keeps" v-if="keep.public == 1" :key="k.id" class="card">
                <h3 class="card-title">{{keep.name}}</h3>
                <div class="container">
                    <img :src="keep.img" alt="">
                    <div class="buttons">
                        <button class="btn" @click="addView(keep)">View</button>
                            <button @click="deleteKeep(keep)">Delete</button>
                        </div>
                    </div>
                </div>
                <h3 class="card-text">{{keep.description}}</h3>
            </div> -->

<!-- KEEP MODAL -->
            <!-- <div class="modal fade" id="viewKeepModal" tabindex="-1" role="dialog" aria-labelledby="viewKeepModalTitle" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">{{viewKeep.name}}</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <form>
                            <div class="modal-body">
                                <div class="container">
                                    <img :src="viewKeep.img" alt="">
                                    <h3 class="card-text">{{viewKeep.description}}</h3>
                                </div>
                                <div class="form-group">
                                    <select v-model="vault">
                                        <option disabled value="">Select a Vault</option>
                                        <option v-for="v in userVaults" :key="v.id" :value="vault">{{vault.name}}</option>
                                    </select>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                                <button type="button" class="btn btn-primary" @click="addVaultKeep(vault)" data-dismiss="modal">Save</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div> -->

    </div>
</template>

<script>
// import router from "../router";
// export default {
//   name: "Keeps",
//   data() {
//     return {
//       keep: {
//         name: "",
//         description: "",
//         img: ""
//       },
//       vault: {
//         name: "",
//         description: ""
//       },
//       viewKeep: {},
//       selectedVault: {}
//     };
//   },
//   components: {},
//   mounted() {
//     this.$store.dispatch("getKeeps");
//   },
//   computed: {
//     user() {
//       return this.$store.state.user;
//     },
//     keeps() {
//       return this.$store.state.keeps;
//     },
//     vaults() {
//       return this.$store.state.vaults;
//     },
//     // userVaults() {
//     //   return this.$store.state.userVaults;
//     // }
//     // activeVault() {
//     //   return this.$store.state.activeVault;
//     // }
//   },
//   methods: {
//     addKeep() {
//       this.$store.dispatch("addKeep", this.keep);
//     },
//     // setKeep(keep) {
//     //   this.$store.dispatch("setKeep", keep);
//     // },

//     editKeep(keep) {
//       this.$store.dispatch("editKeep", keep)
//     },  
//     deleteKeep(keep) {
//       this.$store.dispatch("deleteKeep", keep);
//     },
//     deleteVault(vault) {
//       this.$store.dispatch("deleteVault", vault);
//     },
//     logout() {
//       this.$store.dispatch("logout");
//     }
//   }
// };
</script>

<style>
</style>