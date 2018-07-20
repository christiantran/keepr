<template>
  <div class="container">
    <div class="row">

      <!-- ADD KEEP -->
      <div class="col-7">
        <div class="mt-2">
          <form @submit.prevent="addKeep">
            <input type="text" name="title" v-model="keep.name" placeholder="Keep Name">
            <input type="text" name="description" v-model="keep.description" placeholder="Description">
            <input type="url" name="img" v-model="keep.img" placeholder="Image">
            <button type="submit">Add Keep</button>
          </form>
        </div>

        <!-- VIEW KEEP -->
        <div class="card mt-5" style="width: 18rem;">
          <div v-for="k in keeps" :key="k.id" class="card mt-2">
            <h3 class="card-text">{{k.name}}</h3>
            <h3 class="card-text">{{k.description}}</h3>
            <div class="container">
              <img :src="k.img" alt="">

              <select v-model="selectedVault">
                <option disabled value="">Please select Vault</option>
                <option v-for="v in vaults" :value="v.id" :key="v.id">{{v.name}}</option>
              </select>
              <button type="button" @click="addVaultKeep(k)">Move Keep</button>

              <p>Views:{{k.views}}</p>
              <p>Shares:{{k.shares}}</p>
            </div>
          </div>
        </div>
      </div>

      <!-- ADD VAULT -->
      <div class="col-5">
        <div class="mt-2">
          <form @submit.prevent="addVault">
            <input type="text" name="title" v-model="vault.name" placeholder="Vault Name">
            <input type="text" name="description" v-model="vault.description" placeholder="Description">
            <button type="submit">Add Vault</button>
          </form>
        </div>

        <!-- VIEW VAULT -->
        <div class="card mt-5" style="width: 18rem;">
          <div v-for="v in vaults" :key="v.id" class="card mt-2">
            <router-link :to="{name: 'Vault', params: {vaultId: v.id}}">
              <h3 class="card-text">{{v.name}}</h3>
              <h3 class="card-text">{{v.description}}</h3>
            </router-link>
          </div>

          <!-- VAULT KEEPS -->
          <div v-for="vk in keeps" class="card">
            <h3 class="card-text">{{vk.name}}</h3>
            <h3 class="card-text">{{vk.description}}</h3>
            <div class="container">
              <img :src="vk.img" alt="">
            </div>
          </div>
        </div>
      </div>

    </div>
  </div>
</template>

<script>
  import router from "../router";
  export default {
    name: "Profile",
    components: {
      vaultKeeps: [],
    },
    data() {
      return {
        keep: {
          name: "",
          description: "",
          img: ""
        },
        vault: {
          name: "",
          description: ""
        },
        selectedVault: ""
      };
    },
    mounted() {
      this.$store.dispatch("getKeeps");
      
      //this.$store.dispatch("getVaultKeeps");
      //this.$store.dispatch("getVaults"); //, this.user.id);
    },

    computed: {
      user() {
        return this.$store.state.user;
      },
      keeps() {
        return this.$store.state.keeps;
      },
      vaults() {
        return this.$store.state.userVaults;
      },
      vaultKeeps() {
        return this.$store.state.vaultKeeps;
      }
      // userVaults() {
      //   return this.$store.state.userVaults;
      // }
    },
    methods: {
      addKeep(keep) {
        this.$store.dispatch("addKeep", this.keep);
      },
      addVault(vault) {
        this.$store.dispatch("addVault", this.vault);
      },
      addVaultKeep(keep) {
        var keepId = keep.id;
        var vaultId = this.selectedVault;
        this.$store.dispatch("addVaultKeep", { vaultId, keepId });
        this.selected = "";
      },
      logout() {
        this.$store.dispatch("logout");
      }
      // deleteKeep(keep) {
      //   this.$store.dispatch("deleteKeep", keep);
      // },
      // deleteVault(vault) {
      //   this.$store.dispatch("deleteVault", vault);
      // },
    }
  };
</script>

<style>
</style>