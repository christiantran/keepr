<template>
    <div>
        <div>
            <!-- <li v-for="keep in vault"> -->
                <h3>{{keep.body}}</h3>
                <button @click="deleteKeep(keep)">Delete Keep</button>
        </div>
    </div>
</template>

<script>
import router from "../router";
// import keep from "./Keep";
export default {
  name: "Vaults",
  data() {
    return {
      vault: {
        name: "",
        description: ""
      }
    };
  },
  components: {},
  mounted() {
    this.$store.dispatch("getVaultKeeps", this.vaultId);
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    vaults() {
      return this.$store.state.vaults;
    },
    vaultKeeps() {
      return this.$store.state.vaultKeeps;
    }
  },
  methods: {
    addVault() {
      this.$store.dispatch("addVault", this.vault);
    },
    // deleteVault(vault) {
    //   this.$store.dispatch("deleteVault", vault);
    // },
    // deleteKeep(keep) {
    //   this.$store.dispatch("deleteKeep", keep);
    // },
    logout() {
      this.$store.dispatch("logout");
    }
  }
};
</script>

<style>
</style>