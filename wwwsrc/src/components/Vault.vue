<template>
  <div>
    <div>
      <h1 class="vault-title">{{vault.name}}</h1>
    </div>

    <div v-for="keep in keeps[vault._id]">
      <h2>{{keep.name}}</h2>
      <div>
        <button @click="deleteKeep(keep)">Delete Keep</button>
      </div>
    </div>
  </div>
</template>

<script>
  import router from "../router";
  import keep from "./Keep";
  export default {
    name: "Vaults",
    components: {
      keep
    },
    data() {
      return {
        keep: {
          name: "",
          parentId: ""
        }
      };
    },
    mounted() {
      this.$store.dispatch("getKeeps", this.vault._id);
    },
    computed: {
      user() {
        return this.$store.state.user;
      },
      vaults() {
        return this.$store.state.vaults;
      },
      keeps() {
        return this.$store.state.keeps;
      }
    },
    methods: {
      addVault() {
        this.$store.dispatch("addVault", this.newVault);
      },
      setVault(vault) {
        this.$store.dispatch("setVault", vault);
      },
      deleteVault(vault) {
        this.$store.dispatch("deleteVault", vault);
      },
      deleteKeep(keep) {
        this.$store.dispatch("deleteKeep", keep);
      }
    }
  };
</script>

<style>
</style>