<template>
    <div>
        <div>
            <div v-for="keep in vaultKeeps">
                <h3>{{keep.name}}</h3>
                <button @click="deleteKeep(keep)">Delete Keep</button>
            </div>
        </div>
    </div>
</template>

<script>
export default {
  name: "Vaults",
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
      }
    };
  },
  props: ["vaultId"],
  components: {
    //vaultKeeps: []
  },
  mounted() {
    //this.$store.dispatch("getVaults");
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
    // addVault() {
    //   this.$store.dispatch("addVault", this.vault);
    // },
    deleteVault(vault) {
      this.$store.dispatch("deleteVault", vault);
    },
    deleteKeep(keep) {
      this.$store.dispatch("deleteKeep", keep);
    },
    logout() {
      this.$store.dispatch("logout");
    }
  }
};
</script>

<style>
</style>